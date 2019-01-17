using ExperimentsApp.Data.Model;
using System.Collections.Generic;

namespace ExperimentsApp.Service.Interfaces
{
    public interface IExperimentService
    {
        List<Experiment> GetAll();
        Experiment GetById(int id);
        void AddNewExperiment(Experiment experiment);
        void RemoveExperiment(int id);
    }
}
