using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebPersonToken.Models
{
    public class PersonaDatos
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        public string Name { get; set; }
        public int CovidCount { get; set; }
    }
}