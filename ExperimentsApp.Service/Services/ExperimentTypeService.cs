using System;
using System.Collections.Generic;
using System.Linq;
using ExperimentsApp.Data.DAL;
using ExperimentsApp.Data.Model;
using ExperimentsApp.Service.Interfaces;

namespace ExperimentsApp.Service.Services
{
    public class ExperimentTypeService : IExperimentTypeService
    {
        private readonly ExperimentsDbContext _experimentsDbContext;

        public ExperimentTypeService(ExperimentsDbContext experimentsDbContext)
        {
            _experimentsDbContext = experimentsDbContext;
        }

        public List<ExperimentType> GetAll()
        {
            return _experimentsDbContext.ExperimentTypes.ToList();
        }

        public ExperimentType GetById(int id)
        {
            ExperimentType foundExperimentType = _experimentsDbContext.ExperimentTypes
                .Where(experimentType => experimentType.Id == id)
                .SingleOrDefault();

            return foundExperimentType;
        }

        public void AddNewExperimentType(ExperimentType experimentType)
        {
            _experimentsDbContext.ExperimentTypes.Add(experimentType);
            _experimentsDbContext.SaveChanges();
        }

        public void RemoveExperimentType(int id)
        {
            ExperimentType experimentType = GetById(id);
            if (experimentType == null)
            {
                return;
            }

            _experimentsDbContext.ExperimentTypes.Remove(experimentType);
            _experimentsDbContext.SaveChanges();
        }
    }
}