using ExperimentsApp.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentsApp.Service.Interfaces
{
    public interface IExperimentSensorService
    {
        Task<IList<Sensor>> GetSensorsForExperimentAsync(int experimentId);
        Task AddExperimentSensorAsync(List<ExperimentSensor> experimentSensors);
    }
}
