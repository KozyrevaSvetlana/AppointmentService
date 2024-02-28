namespace Appointment.Service.Models
{
    public interface IRabitMQProducer
    {
        public void SendProductMessage<T>(T message);
    }
}
