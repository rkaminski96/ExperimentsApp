using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExperimentsApp.Data.DAL;
using ExperimentsApp.Data.Model;
using ExperimentsApp.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExperimentsApp.Service.Services
{
    public class MachineService : IMachineService
    {
        private readonly ExperimentsDbContext _experimentsDbContext;

        public MachineService(ExperimentsDbContext experimentsDbContext)
        {
            _experimentsDbContext = experimentsDbContext;
        }

        public async Task<IList<Machine>> GetMachinesAsync()
        {
            return await _experimentsDbContext.Machines.ToListAsync();
        }

        public async Task<Machine> GetMachineByIdAsync(int id)
        {
            var machine = await _experimentsDbContext.Machines.FirstOrDefaultAsync(s => s.Id == id);
            return machine;
        }

        public async Task AddMachineAsync(Machine machine)
        {
            await _experimentsDbContext.Machines.AddAsync(machine);
        }

        public async Task DeleteMachineAsync(Machine machine)
        {
            _experimentsDbContext.Machines.Remove(machine);
            await Task.CompletedTask;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _experimentsDbContext.SaveChangesAsync() >= 0;
        }
    }
}