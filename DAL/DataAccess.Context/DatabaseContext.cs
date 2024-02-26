using Microsoft.EntityFrameworkCore;

namespace Appointment.EntityFramework
{
    /// <summary>
    /// Контекст
    /// </summary>
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext>options) : base(options)
        {
        }
        
        /// <summary>
        /// Записи на прием
        /// </summary>
        public DbSet<Entities.Appointment>Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Entities.Appointment>();
        }
    }
}