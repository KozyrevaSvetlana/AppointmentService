using Services.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appointment.Repositories
{
    /// <summary>
    /// Интерфейс репозитория работы с курсами.
    /// </summary>
    public interface IAppointmentRepository : IRepository<Entities.Appointment, Guid>
    {
        /// <summary>
        /// Получить все записи
        /// </summary>
        /// <returns>Список записей</returns>
        Task<List<Entities.Appointment>> GetAllAsync();

        /// <summary>
        /// Получить записи постранично
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<ICollection<Entities.Appointment>> GetPagedAsync(int page, int pageSize);

    }
}
