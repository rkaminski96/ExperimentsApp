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

        public async Task<Sensor> GetSensorByIdAsync(int sensorId)
        {
            return await _experimentsDbContext.Sensors.FirstOrDefaultAsync(s => s.Id == sensorId);
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

        public async Task<IList<Sensor>> GetSensorsByIds(IList<int> sensorIds)
        {
            var sensors = await _experimentsDbContext.Sensors.Where(s => sensorIds.Contains(s.Id)).ToListAsync();
            return  sensors;
        }
    }
}
