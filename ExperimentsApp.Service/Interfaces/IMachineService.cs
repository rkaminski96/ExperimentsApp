using ExperimentsApp.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExperimentsApp.Service.Interfaces
{
    public interface IMachineService
    {
        Task<IList<Machine>> GetMachinesAsync();
        Task<Machine> GetMachineByIdAsync(int id);
        Task AddMachineAsync(Machine machine);
        Task DeleteMachineAsync(Machine machine);
        Task<bool> SaveChangesAsync();
    }
}
