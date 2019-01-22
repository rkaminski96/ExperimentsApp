﻿using ExperimentsApp.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExperimentsApp.Service.Interfaces
{
    public interface IExperimentService
    {
        Task<IList<Experiment>> GetExperimentsAsync(int userId);
        Task<Experiment> GetExperimentByIdAsync(int userId, int experimentId);
        Task AddExperimentAsync(int userId, Experiment experiment);
        //Task DeleteExperimentAsync(int userId, Experiment experiment);
        Task<bool> SaveChangesAsync();
    }
}
