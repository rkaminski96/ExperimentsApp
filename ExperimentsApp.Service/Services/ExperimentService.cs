﻿using System.Collections.Generic;
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
                                    .ToListAsync();
            return experiments; 
        }

        public async Task<Experiment> GetExperimentByIdAsync(int userId, int experimentId)
        {
            var experiment = await _experimentsDbContext.Experiments
                                    .FirstOrDefaultAsync(x => x.UserId == userId && x.Id == experimentId);
            return experiment;
        }

        public async Task AddExperimentAsync(int userId, Experiment experiment)
        {
            await _experimentsDbContext.AddAsync(experiment);
        }

        /* public async Task DeleteExperimentAsync(int userId, Experiment experiment)
        {
            throw new System.NotImplementedException();
        } */

        public async Task<bool> SaveChangesAsync()
        {
            return await _experimentsDbContext.SaveChangesAsync() >= 0;
        }
    }
}