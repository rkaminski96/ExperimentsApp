﻿using System.ComponentModel.DataAnnotations;

namespace ExperimentsApp.Data.Dto
{
    public class MachineRequest
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        public string Type { get; set; }
    }
}
