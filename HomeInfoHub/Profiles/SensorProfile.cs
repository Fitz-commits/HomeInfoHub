using AutoMapper;
using HomeInfoHub.DTO;
using HomeInfoHub.Entities;

namespace HomeInfoHub.Profiles
{
    public class SensorProfile : Profile
    {
        public SensorProfile()
        {
            CreateMap<SensorForCreationDto, Sensor>();
        }
    }
}
