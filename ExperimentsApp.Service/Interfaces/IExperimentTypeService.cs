using ExperimentsApp.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExperimentsApp.Service.Interfaces
{
    public interface IExperimentTypeService
    {
        Task<IList<ExperimentType>> GetExperimentTypesAsync();
        Task<ExperimentType> GetExperimentTypeByIdAsync(int id);
        Task AddExperimentTypeAsync(ExperimentType experimentType);
        Task DeleteExperimentTypeAsync(ExperimentType experimentType);
        Task<bool> SaveChangesAsync();
    }
}

