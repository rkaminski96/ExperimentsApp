using ExperimentsApp.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExperimentsApp.Service.Interfaces
{
    public interface IMachineService
    {
        List<Machine> GetAll();
        Machine GetById(int id);
        void AddNewMachine(Machine machine);
        void RemoveMachine(int id);
    }
}
