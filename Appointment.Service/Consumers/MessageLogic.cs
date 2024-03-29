﻿using Appointment.Service.Models;
using MassTransit;

namespace Appointment.Service.Consumers
{
    public class MessageLogic: IMessageLogic
    {
        private readonly ILogger<MessageLogic> _logger;
        private readonly IBusControl _bus;

        public MessageLogic(ILogger<MessageLogic> logger, IBusControl bus)
        {
            _logger = logger;
            _bus = bus;
        }

        public async Task SomeMethod(string message)
        {
            _logger.LogInformation(message);
            await Task.CompletedTask;
        }
    }
}
