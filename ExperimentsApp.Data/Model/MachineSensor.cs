﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExperimentsApp.Data.Model
{
    public class MachineSensor
    {
        [ForeignKey("Machine")]
        public int MachineId { get; set; }
        public Machine Machine { get; set; }

        [ForeignKey("Sensor")]
        public int SensorId { get; set; }
        public Sensor Sensor { get; set; }
    }
}
