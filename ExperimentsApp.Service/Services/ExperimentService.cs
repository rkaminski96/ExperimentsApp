using System.Collections.Generic;
using System.Linq;
using ExperimentsApp.Data.DAL;
using ExperimentsApp.Data.Model;
using ExperimentsApp.Service.Interfaces;

namespace ExperimentsApp.Service.Services
{
    public class ExperimentService : IExperimentService
    {
        private readonly ExperimentsDbContext _experimentsDbContext;

        public ExperimentService(ExperimentsDbContext experimentsDbContext)
        {
            _experimentsDbContext = experimentsDbContext;
        }

        public List<Experiment> GetAll()
        {
            return _experimentsDbContext.Experiments.ToList();
        }

        public Experiment GetById(int id)
        {
            Experiment foundExperiment = _experimentsDbContext.Experiments
                .Where(experiment => experiment.Id == id)
                .SingleOrDefault();

            return foundExperiment;
        }

        public void AddNewExperiment(Experiment experiment)
        {
            _experimentsDbContext.Experiments.Add(experiment);
            _experimentsDbContext.SaveChanges();
        }

        public void RemoveExperiment(int id)
        {
            Experiment experiment = GetById(id);
            if (experiment == null)
            {
                return;
            }

            _experimentsDbContext.Experiments.Remove(experiment);
            _experimentsDbContext.SaveChanges();
        }
    }
}