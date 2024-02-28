using Microsoft.AspNetCore.Authentication.OAuth;

namespace Appointment.Service.Configs
{
    public interface IApplicationConfig
    {
        RabbitMqConfig BusConfig { get; set; }
    }
}
