using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExperimentsApp.Data.Model
{
    public class Experiment
    { 

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDateTime { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }

        [ForeignKey("ExperimentType")]
        public int ExperimentTypeId { get; set; }
        public ExperimentType ExperimentType { get; set; }

        [ForeignKey("Machine")]
        public int MachineId { get; set; }
        public Machine Machine { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }

        public List<ExperimentSensor> ExperimentSensors { get; set; } = new List<ExperimentSensor>();
 
        protected Experiment()
        {

        }

        public Experiment(string name, string description, string path, Machine machine, ExperimentType experimentType, User user)
        {
            Name = name;
            Description = description;
            Path = path;
            Machine = machine;
            MachineId = machine.Id;
            ExperimentType = experimentType;
            ExperimentTypeId = experimentType.Id;
            User = user;
            UserId = user.Id;
            CreationDateTime = DateTime.Now;
        }
    }
}
 