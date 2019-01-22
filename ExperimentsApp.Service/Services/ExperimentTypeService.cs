using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExperimentsApp.Data.DAL;
using ExperimentsApp.Data.Model;
using ExperimentsApp.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExperimentsApp.Service.Services
{
    public class ExperimentTypeService : IExperimentTypeService
    {
        private readonly ExperimentsDbContext _experimentsDbContext;

        public ExperimentTypeService(ExperimentsDbContext experimentsDbContext)
        {
            _experimentsDbContext = experimentsDbContext;
        }

        public async Task<IList<ExperimentType>> GetExperimentTypesAsync()
        {
            return await _experimentsDbContext.ExperimentTypes.ToListAsync();
        }

        public async Task<ExperimentType> GetExperimentTypeByIdAsync(int experimentTypeId)
        {
            var experimentType = await _experimentsDbContext.ExperimentTypes.FirstOrDefaultAsync(s => s.Id == experimentTypeId);
            return experimentType;
        }

        public async Task AddExperimentTypeAsync(ExperimentType experimentType)
        {
            await _experimentsDbContext.ExperimentTypes.AddAsync(experimentType);         
        }

        public async Task DeleteExperimentTypeAsync(ExperimentType experimentType)
        {
            _experimentsDbContext.ExperimentTypes.Remove(experimentType);
            await Task.CompletedTask;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _experimentsDbContext.SaveChangesAsync() >= 0;
        }
    }
}