using ExperimentsApp.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

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

