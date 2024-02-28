using Appointment.Service.Models;

namespace Appointment.Service.Consumers
{
    public interface IMessageLogic
    {
        Task SomeMethod(string message);
    }
}
