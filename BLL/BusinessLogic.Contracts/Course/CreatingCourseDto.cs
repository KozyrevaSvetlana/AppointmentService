using Appointment.Entities;
using System;

namespace BusinessLogic.Contracts.Appointment
{
    /// <summary>
    /// ДТО записи
    /// </summary>
    public class CreatingAppointmentDto
    {
        /// <summary>
        /// Стоимость
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Продолжительность приема
        /// </summary>
        public DurationEnum Duration { get; set; }
        /// <summary>
        /// Время начала записи
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// Идентификатор врача
        /// </summary>
        public Guid DoctorId { get; set; }
        /// <summary>
        /// Идентификатор пациента
        /// </summary>
        public Guid PatientId { get; set; }
    }
}