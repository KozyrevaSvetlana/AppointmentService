using AutoMapper;
using BusinessLogic.Contracts.Appointment;

namespace BusinessLogic.Services.Mapping
{
    /// <summary>
    /// Профиль автомаппера для сущности курса.
    /// </summary>
    public class AppointmentMappingsProfile : Profile
    {
        public AppointmentMappingsProfile()
        {
            CreateMap<Appointment.Entities.Appointment, AppointmentDto>();

            CreateMap<CreatingAppointmentDto, Appointment.Entities.Appointment>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.IsDeleted, map => map.Ignore());

            CreateMap<UpdatingAppointmentDto, Appointment.Entities.Appointment>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.IsDeleted, map => map.Ignore());
        }
    }
}