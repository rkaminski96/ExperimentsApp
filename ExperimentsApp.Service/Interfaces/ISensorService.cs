using System.Collections.Generic;
using System.Threading.Tasks;
using ExperimentsApp.Data.Model;

namespace ExperimentsApp.Service.Interfaces
{
    public interface ISensorService
    {
        Task<IList<Sensor>> GetSensorsAsync();
        Task<Sensor> GetSensorByIdAsync(int id);
        Task AddSensorAsync(Sensor sensor);
        Task DeleteSensorAsync(Sensor sensor);
        Task<bool> SaveChangesAsync();
    }
}
