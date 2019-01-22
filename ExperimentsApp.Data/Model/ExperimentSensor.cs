using System.ComponentModel.DataAnnotations.Schema;


namespace ExperimentsApp.Data.Model
{
    public class ExperimentSensor
    {
        [ForeignKey("Experiment")]
        public int ExperimentId { get; set; }
        public Experiment Experiment { get; set; }

        [ForeignKey("Sensor")]
        public int SensorId { get; set; }
        public Sensor Sensor { get; set; }
    }
}
