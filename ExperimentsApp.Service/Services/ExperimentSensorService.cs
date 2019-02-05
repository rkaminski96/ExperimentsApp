using ExperimentsApp.Data.DAL;
using ExperimentsApp.Data.Model;
using ExperimentsApp.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentsApp.Service.Services
{
    public class ExperimentSensorService : IExperimentSensorService
    {
        private readonly ExperimentsDbContext _experimentsDbContext;


        public ExperimentSensorService(ExperimentsDbContext experimentsDbContext)
        {
            _experimentsDbContext = experimentsDbContext;
        }


        public async Task AddExperimentSensorAsync(List<ExperimentSensor> experimentSensors)
        {
            await _experimentsDbContext.ExperimentSensors.AddRangeAsync(experimentSensors);
        }

        public async Task<IList<Sensor>> GetSensorsForExperimentAsync(int experimentId)
        {
            var sensors = await _experimentsDbContext.ExperimentSensors
                                   .Where(s => s.Experiment.Id == experimentId)
                                   .Select(s => s.Sensor)
                                   .ToListAsync();
            return sensors;
        }
    }
}
