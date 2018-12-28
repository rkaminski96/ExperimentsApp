using ExperimentsApp.Data.Dto;
using ExperimentsApp.Data.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExperimentsApp.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ExperimentRequest, Experiment>();
            CreateMap<Experiment, ExperimentResponse>();

            CreateMap<ExperimentTypeRequest, ExperimentType>();
            CreateMap<ExperimentType, ExperimentTypeResponse>();

            CreateMap<MachineRequest, Machine>();
            CreateMap<Machine, MachineResponse>();

            CreateMap<SensorRequest, Sensor>();
            CreateMap<Sensor, SensorResponse>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
