using System.Collections.Generic;
using System.Linq;
using ExperimentsApp.Data.DAL;
using ExperimentsApp.Data.Model;
using ExperimentsApp.Service.Interfaces;

namespace ExperimentsApp.Service.Services
{
    public class SensorService : ISensorService
    {
        private readonly ExperimentsDbContext _experimentsDbContext;

        public SensorService(ExperimentsDbContext experimentsDbContext)
        {
            _experimentsDbContext = experimentsDbContext;
        }

        public List<Sensor> GetAll()
        {
            return _experimentsDbContext.Sensors.ToList();
        }

        public Sensor GetById(int id)
        {
            Sensor foundSensor = _experimentsDbContext.Sensors
                .Where(sensor => sensor.Id == id)
                .SingleOrDefault();

            return foundSensor;
        }

        public void AddNewSensor(Sensor sensor)
        {
            _experimentsDbContext.Sensors.Add(sensor);
            _experimentsDbContext.SaveChanges();
        }

        public void RemoveSensor(int id)
        {
            Sensor sensor = GetById(id);
            if (sensor == null) 
            {
                return;
            }

            _experimentsDbContext.Sensors.Remove(sensor);
            _experimentsDbContext.SaveChanges();
        }
    }
}
