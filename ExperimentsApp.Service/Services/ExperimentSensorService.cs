using ExperimentsApp.Data.DAL;
using ExperimentsApp.Data.Model;
using ExperimentsApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentsApp.Service.Services
{
    public class ExperimentSensorService : IExperimentSensorService
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

        //public async Task<ExperimentSensor> GetExperimentByIdAsync(int userId, int experimentId)
        //{
         //   var experiment = await _experimentsDbContext.ExperimentSensors
          //                          .FirstOrDefaultAsync(x => x.UserId == userId && x.Id == experimentId);
          //  return experiment;  
        //}
    }
}
