using Appointment.Service.Models;
using BusinessLogic.Abstractions;
using BusinessLogic.Contracts.Appointment;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IRabitMQProducer _rabitMQProducer;
        public AppointmentController(IAppointmentService appointmentService, IRabitMQProducer rabitMQProducer)
        {
            _appointmentService = appointmentService;
            _rabitMQProducer = rabitMQProducer;
        }
        [HttpGet("GetPaged")]
        public async Task<IEnumerable<AppointmentDto>> AppointmentList(int page, int pageSize)
        {
            return await _appointmentService.GetPagedAsync(page, pageSize);
        }
        [HttpGet("GetAppointmentbyId")]
        public async Task<AppointmentDto> GetAppointmentById(Guid id)
        {
            return await _appointmentService.GetByIdAsync(id);
        }
        [HttpPost("AddAppointment")]
        public async Task AddAppointment(CreatingAppointmentDto appointment)
        {
        }
        [HttpPut("updateAppointment")]
        public async Task UpdateAppointment()
        {
        }
        [HttpDelete("deleteAppointment")]
        public async Task<bool> DeleteAppointment(int Id)
        {
            return false;
        }
    }
}
