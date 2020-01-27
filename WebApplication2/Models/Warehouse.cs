using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public String Location { get; set; }
        [Required]
        [Display(Name = "Capacity")]
        public int capacity { get; set; }
        [Required]
        [Display(Name = "Supervisor")]
        public string supervisor { get; set; }

        // orders
    }
}