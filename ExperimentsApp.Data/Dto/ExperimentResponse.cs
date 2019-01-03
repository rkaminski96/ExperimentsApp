﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExperimentsApp.Data.Dto
{
    public class ExperimentResponse
    {
        public int ExperimentId { get; set; }
        public string Name { get; set; }
        public DateTime CreationDateTime { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
    }
}