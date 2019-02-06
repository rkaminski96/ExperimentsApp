using ExperimentsApp.Data.Dto;
using ExperimentsApp.Data.Model;
using AutoMapper;
using System.Globalization;

namespace ExperimentsApp.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ExperimentRequest, Experiment>();
            CreateMap<Experiment, ExperimentResponse>()
                .ForMember(dest => dest.CreationDateTime, opt => opt.MapFrom(src => src.CreationDateTime.ToString()));

            CreateMap<ExperimentTypeRequest, ExperimentType>();
            CreateMap<ExperimentType, ExperimentTypeResponse>();

            CreateMap<MachineRequest, Machine>();
            CreateMap<Machine, MachineResponse>();

            CreateMap<SensorRequest, Sensor>();
            CreateMap<Sensor, SensorResponse>();

            CreateMap<User, UserDisplay>();
            CreateMap<UserLogin, User>();
            CreateMap<UserRegistration, User>();
        }
    }
}
