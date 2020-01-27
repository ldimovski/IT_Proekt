using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Order : IValidatableObject
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Wharehouse")]
        public int warehouse_id { get; set; }
        [Required]
        [Display(Name = "Capacity")]
        public int kolicina { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        public DateTime poceten_datum { get; set; }
        [Required]
        [Display(Name = "End Date")]
        public DateTime kraen_datum { get; set; }
        [StringLength(50)]
        [Display(Name = "By")]
        public String Od { get; set; }
        [Required]
        [Display(Name = "Description")]
        public String Opis { get; set; }

        public Warehouse magacini { get; set; }

        public String approved { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            List<ValidationResult> res = new List<ValidationResult>();
            if (poceten_datum > kraen_datum)
            {
                ValidationResult mss = new ValidationResult("End date must be after start date!");
                res.Add(mss);
            }
            if (poceten_datum < DateTime.Today)
            {
                ValidationResult mss = new ValidationResult("Starting date must be after today!");
                res.Add(mss);
            }
            return res;
        }


    }
}