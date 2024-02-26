using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.Contracts.Appointment;

namespace BusinessLogic.Abstractions
{
    /// <summary>
    /// Cервис работы с курсами (интерфейс)
    /// </summary>
    public interface IAppointmentService
    {
        /// <summary>
        /// Получить список курсов.
        /// </summary>
        /// <param name="page">Номер страницы</param>
        /// <param name="pageSize">Объем страницы</param>
        /// <returns>Список курсов</returns>
        Task<ICollection<AppointmentDto>> GetPagedAsync(int page, int pageSize);

        /// <summary>
        /// Получить запись
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>ДТО курса</returns>
        Task<AppointmentDto> GetByIdAsync(Guid id);

        /// <summary>
        /// Создать запись
        /// </summary>
        /// <param name="creatingAppointmentDto">ДТО создаваемого курса</param>
        Task<Guid> CreateAsync(CreatingAppointmentDto creatingAppointmentDto);

        /// <summary>
        /// Изменить запись
        /// </summary>
        /// <param name="id">Иентификатор</param>
        /// <param name="updatingAppointmentDto">ДТО редактируемого курса</param>
        Task UpdateAsync(Guid id, UpdatingAppointmentDto updatingAppointmentDto);

        /// <summary>
        /// Удалить запись
        /// </summary>
        /// <param name="id">Идентификатор</param>
        Task DeleteAsync(Guid id);
    }
}