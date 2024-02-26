using Appointment.Repositories;
using AutoMapper;
using BusinessLogic.Abstractions;
using BusinessLogic.Contracts.Appointment;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    /// <summary>
    /// Cервис работы с записями
    /// </summary>
    public class AppointmentService : IAppointmentService
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository appointmentRepository;

        public AppointmentService(
            IMapper mapper,
            IAppointmentRepository appointmentRepository)
        {
            _mapper = mapper;
            this.appointmentRepository = appointmentRepository;
        }

        /// <summary>
        /// Получить список курсов.
        /// </summary>
        /// <param name="page">Номер страницы</param>
        /// <param name="pageSize">Объем страницы</param>
        /// <returns>Список курсов</returns>
        public async Task<ICollection<AppointmentDto>> GetPagedAsync(int page, int pageSize)
        {
            var entities = await appointmentRepository.GetPagedAsync(page, pageSize);
            return _mapper.Map<ICollection<Appointment.Entities.Appointment>, ICollection<AppointmentDto>>(entities);
        }

        /// <summary>
        /// Получить запись
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>ДТО курса</returns>
        public async Task<AppointmentDto> GetByIdAsync(Guid id)
        {
            var appointment = await appointmentRepository.GetAsync(id);
            return _mapper.Map<AppointmentDto>(appointment);
        }

        /// <summary>
        /// Создать запись
        /// </summary>
        /// <param name="creatingAppointmentDto">ДТО создаваемого курса</param>
        /// <returns>Идентификатор</returns>
        public async Task<Guid> CreateAsync(CreatingAppointmentDto creatingAppointmentDto)
        {
            var appointment = _mapper.Map<CreatingAppointmentDto, Appointment.Entities.Appointment>(creatingAppointmentDto);
            var createdAppointment = await appointmentRepository.AddAsync(appointment);
            await appointmentRepository.SaveChangesAsync();
            return createdAppointment.Id;
        }

        /// <summary>
        /// Изменить запись
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="updatingAppointmentDto">ДТО редактируемого курса</param>
        public async Task UpdateAsync(Guid id, UpdatingAppointmentDto updatingAppointmentDto)
        {
            var appointment = await appointmentRepository.GetAsync(id);
            if (appointment == null)
                throw new Exception($"Запись с идентфикатором {id} не найдена");

            appointment.Price = updatingAppointmentDto.Price;
            appointment.Duration = (int)updatingAppointmentDto.Duration;
            appointment.Time = updatingAppointmentDto.Time;
            appointment.DoctorId = updatingAppointmentDto.DoctorId;
            appointment.PatientId = updatingAppointmentDto.PatientId;
            appointment.Status = (int)updatingAppointmentDto.Status;
            appointmentRepository.Update(appointment);
            await appointmentRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить запись
        /// </summary>
        /// <param name="id">Идентификатор</param>
        public async Task DeleteAsync(Guid id)
        {
            var appointment = await appointmentRepository.GetAsync(id);
            if (appointment == null)
                throw new Exception($"Запись с идентфикатором {id} не найдена");
            appointment.IsDeleted = true;
            await appointmentRepository.SaveChangesAsync();
        }
    }
}