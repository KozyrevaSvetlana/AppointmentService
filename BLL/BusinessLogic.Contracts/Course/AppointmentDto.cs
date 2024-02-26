using System;
namespace BusinessLogic.Contracts.Appointment
{
    /// <summary>
    /// ДТО записи
    /// </summary>
    public class AppointmentDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Стоимость
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Продолжительность приема
        /// </summary>
        public int Duration { get; set; }
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

        /// <summary>
        /// Статус
        /// </summary>
        public string Status { get; set; }
    }
}