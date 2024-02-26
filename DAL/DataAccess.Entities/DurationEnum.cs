using System.ComponentModel;

namespace Appointment.Entities
{
    public enum DurationEnum
    {
        [Description("Нет записи")]
        None = 0,
        [Description("Десять минут")]
        TenMinutes = 10,
        [Description("Четверть часа")]
        Fifth = 12,
        [Description("Четвертая часть часа")]
        Quarter = 15,
        [Description("Полчаса")]
        Half = 30
    }
}
