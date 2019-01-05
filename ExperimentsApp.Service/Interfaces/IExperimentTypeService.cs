using ExperimentsApp.Data.Model;
using System.Collections.Generic;

namespace ExperimentsApp.Service.Interfaces
{
    public interface IExperimentTypeService
    {
        List<ExperimentType> GetAll();
        ExperimentType GetById(int id);
        void AddNewExperimentType(ExperimentType experimentType);
        void RemoveExperimentType(int id);
    }
}

