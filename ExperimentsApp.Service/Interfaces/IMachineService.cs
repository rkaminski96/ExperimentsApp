using ExperimentsApp.Data.Model;
using System.Collections.Generic;

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
