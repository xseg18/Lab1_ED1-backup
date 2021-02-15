using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lab1_ED1__backup_.Models
{
    public class Player
    {
        [Display(Name = "Nombre")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Apellido")]
        [Required]
        public string LName { get; set; }
        [Display(Name = "Club")]
        [Required]
        public string Club { get; set; }
        [Display(Name = "Salario")]
        [Required]
        public double Pay { get; set; }
        [Display(Name = "Posición")]
        [Required]
        public string Position { get; set; }
        [Display(Name = "Compensación")]
        [Required]
        public double Compensation { get; set; }
    }
}
