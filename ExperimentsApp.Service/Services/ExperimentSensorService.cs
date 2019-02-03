using ExperimentsApp.Data.DAL;
using ExperimentsApp.Data.Model;
using ExperimentsApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentsApp.Service.Services
{
    public class ExperimentSensorService : IExperimentSensor
    {
        private readonly ExperimentsDbContext _experimentsDbContext;

        public ExperimentSensorService(ExperimentsDbContext experimentDbContext)
        {
            _experimentsDbContext = experimentDbContext;
        }

        public async Task AddExperimentSensorAsync(List<ExperimentSensor> experimentSensors)
        {
            await _experimentsDbContext.ExperimentSensors.AddRangeAsync(experimentSensors);
        }
    }
}
