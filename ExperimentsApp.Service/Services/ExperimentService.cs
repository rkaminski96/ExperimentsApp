using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExperimentsApp.Data.DAL;
using ExperimentsApp.Data.Model;
using ExperimentsApp.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExperimentsApp.Service.Services
{
    public class ExperimentService : IExperimentService
    {
        private readonly ExperimentsDbContext _experimentsDbContext;

        public ExperimentService(ExperimentsDbContext experimentsDbContext)
        {
            _experimentsDbContext = experimentsDbContext;
        }

        public async Task<IList<Experiment>> GetExperimentsAsync(int userId)
        {
            var experiments = await _experimentsDbContext.Experiments
                                    .Where(x => x.UserId == userId)
                                    .Include(e => e.Machine)
                                    .Include(e => e.ExperimentType)
                                    .ToListAsync();
            return experiments; 
        }

        public async Task<Experiment> GetExperimentByIdAsync(int userId, int experimentId)
        {
            var experiment = await _experimentsDbContext.Experiments
                                    .FirstOrDefaultAsync(x => x.UserId == userId && x.Id == experimentId);
            return experiment;
        }

        public async Task AddExperimentAsync(Experiment experiment)
        {
            await _experimentsDbContext.AddAsync(experiment);
        }


        public async Task DeleteExperimentAsync(Experiment experiment)
        {
            _experimentsDbContext.Experiments.Remove(experiment);
            await Task.CompletedTask;
        }


        public async Task<bool> SaveChangesAsync()
        {
            return await _experimentsDbContext.SaveChangesAsync() >= 0;
        }
    }
}