using System;
using System.Collections.Generic;
using System.Text;
using ExperimentsApp.Data.Model;

namespace ExperimentsApp.Service.Interfaces
{
    public interface ISensorService
    {
        List<Sensor> GetAll();
        Sensor GetById(int id);
        void AddNewSensor(Sensor sensor);
        void RemoveSensor(int id);
    }
}
