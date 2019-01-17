using System;

namespace ExperimentsApp.Data.Dto
{
    public class ExperimentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDateTime { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
    }
}
