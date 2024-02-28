namespace Appointment.Service.Configs
{
    public class ApplicationConfig: IApplicationConfig
    {
        public RabbitMqConfig BusConfig { get; set; } = default!;
    }
}
