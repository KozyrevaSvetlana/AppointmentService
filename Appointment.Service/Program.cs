using Appointment.EntityFramework;
using Appointment.Repositories;
using Appointment.Service.Configs;
using Appointment.Service.Consumers;
using Appointment.Service.Models;
using AutoMapper;
using BusinessLogic.Abstractions;
using BusinessLogic.Services;
using BusinessLogic.Services.Mapping;
using MassTransit;
using System.Transactions;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", false, true)
    .AddJsonFile("appsettings.Development.json", true)
    .Build();

if (configuration.Get<ApplicationConfig>() is not IApplicationConfig receptionConfig)
    throw new ConfigurationException("Не удалось прочитать конфигурацию сервиса");
builder.Services.AddSingleton<IMapper>(new Mapper(new MapperConfiguration(cfg =>
{
    cfg.AddProfile<AppointmentMappingsProfile>();

})));
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddDbContext<DatabaseContext>();
builder.Services.AddTransient<IRabitMQProducer, RabitMQProducer>();
builder.Services.AddTransient<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddTransient<IMessageLogic, MessageLogic>();
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMassTransit(x =>
{
    //x
    //.AddRequestManagerConsumerType<IAuthResponse>()
    //.AddRequestManagerConsumerType<IUnifiedReceptionResponse>()
    //.AddConsumers();

    x.AddConsumer<BaseConsumer>();


    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(receptionConfig.BusConfig.Host, receptionConfig.BusConfig.Port, receptionConfig.BusConfig.Path, h =>
        {
            h.Username(receptionConfig.BusConfig.Username);
            h.Password(receptionConfig.BusConfig.Password);
        });

        cfg.UseTransaction(_ =>
        {
            _.Timeout = TimeSpan.FromSeconds(20);
            _.IsolationLevel = IsolationLevel.ReadCommitted;
        });

        cfg.ReceiveEndpoint(new TemporaryEndpointDefinition(), e =>
        {
            e.ConfigureConsumer<BaseConsumer>(context);
        });
        cfg.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


