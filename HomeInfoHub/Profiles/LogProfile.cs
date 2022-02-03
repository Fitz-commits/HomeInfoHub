using AutoMapper;
using HomeInfoHub.DTO;
using HomeInfoHub.Entities;

namespace HomeInfoHub.Profiles
{
    public class LogProfile : Profile
    {
        public LogProfile()
        {
            CreateMap<LogForCreationDto, Log>();
        }
    }
}
