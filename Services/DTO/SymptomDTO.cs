using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Services.DTO
{
    public class SymptomDTO
    {
        public int? Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
