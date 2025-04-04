using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinary.Shared.Entities
{
    public  class PetType
    {
        public int Id { get; set; }


        [Display(Name = "Tipo de mascota")]
        [Required]
        [MaxLength(50)]

        public string Name { get; set; }


    }
}
