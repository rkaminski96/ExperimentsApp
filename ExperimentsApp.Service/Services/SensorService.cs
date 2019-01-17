using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExperimentsApp.Data.DAL;
using ExperimentsApp.Data.Model;
using ExperimentsApp.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExperimentsApp.Service.Services
{
    public class SensorService : ISensorService
    {
        private readonly ExperimentsDbContext _experimentsDbContext;

        public SensorService(ExperimentsDbContext experimentsDbContext)
        {
            _experimentsDbContext = experimentsDbContext;
        }

        public async Task<IList<Sensor>> GetSensorsAsync()
        {
            return await _experimentsDbContext.Sensors.ToListAsync();
        }

        public async Task<Sensor> GetSensorByIdAsync(int id)
        {
            return await _experimentsDbContext.Sensors.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddSensorAsync(Sensor sensor)
        {
            await _experimentsDbContext.AddAsync(sensor);
        }

        public async Task DeleteSensorAsync(Sensor sensor)
        {
            _experimentsDbContext.Sensors.Remove(sensor);
            await Task.CompletedTask;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _experimentsDbContext.SaveChangesAsync() >= 0;
        }
    }
}
