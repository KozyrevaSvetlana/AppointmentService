using Appointment.Service.Models;
using MassTransit;

namespace Appointment.Service.Consumers
{
    public class BaseConsumer: IConsumer<BaseResponse>
    {
        private readonly IMessageLogic messageLogic;

        public BaseConsumer(IMessageLogic messageLogic)
        {
            this.messageLogic = messageLogic;
        }

        public async Task Consume(ConsumeContext<BaseResponse> context)
        {

            await messageLogic.SomeMethod(context.Message.Body);
        }
    }
}
