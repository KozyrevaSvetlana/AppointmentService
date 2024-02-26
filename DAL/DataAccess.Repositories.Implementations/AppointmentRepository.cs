using Appointment.EntityFramework;
using Infrastructure.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appointment.Repositories
{
    /// <summary>
    /// Репозиторий работы с курсами.
    /// </summary>
    public class AppointmentRepository : Repository<Entities.Appointment, Guid>, IAppointmentRepository
    {

        public AppointmentRepository(DatabaseContext context) : base(context)
        {
        }

        /// <summary>
        /// Получить список
        /// </summary>
        /// <returns>Список записей</returns>
        public async Task<List<Entities.Appointment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Entities.Appointment>> GetPagedAsync(int page, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
