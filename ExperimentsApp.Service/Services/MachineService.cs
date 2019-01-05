using System.Collections.Generic;
using System.Linq;
using ExperimentsApp.Data.DAL;
using ExperimentsApp.Data.Model;
using ExperimentsApp.Service.Interfaces;

namespace ExperimentsApp.Service.Services
{
    public class MachineService : IMachineService
    {
        private readonly ExperimentsDbContext _experimentsDbContext;

        public MachineService(ExperimentsDbContext experimentsDbContext)
        {
            _experimentsDbContext = experimentsDbContext;
        }

        public List<Machine> GetAll()
        {
            return _experimentsDbContext.Machines.ToList();
        }

        public Machine GetById(int id)
        {
            Machine foundMachine = _experimentsDbContext.Machines
                .Where(machine => machine.Id == id)
                .SingleOrDefault();

            return foundMachine;
        }

        public void AddNewMachine(Machine machine)
        {
            _experimentsDbContext.Machines.Add(machine);
            _experimentsDbContext.SaveChanges();
        }

        public void RemoveMachine(int id)
        {
            Machine machine = GetById(id);
            if (machine == null)
            {
                return;
            }

            _experimentsDbContext.Machines.Remove(machine);
            _experimentsDbContext.SaveChanges();
        }
    }
}