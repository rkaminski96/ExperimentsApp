using AutoMapper;
using ExperimentsApp.Data.Model;
using ExperimentsApp.Data.Dto;

namespace ExperimentsApp.API.Mapping
{
    public class SensorMappingProfile : Profile
    {
        public SensorMappingProfile()
        {
            CreateMap<SensorRequest, Sensor>();
            CreateMap<Sensor, SensorResponse>();
        }
    }
}
