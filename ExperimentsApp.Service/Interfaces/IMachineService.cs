using ExperimentsApp.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExperimentsApp.Service.Interfaces
{
    public interface IMachineService
    {
        Task<IList<Machine>> GetMachinesAsync();
        Task<Machine> FindMachineByNameAsync(string name);
        Task<Machine> GetMachineByIdAsync(int machineId);
        Task AddMachineAsync(Machine machine);
        Task DeleteMachineAsync(Machine machine);
        Task<bool> SaveChangesAsync();
    }
}
