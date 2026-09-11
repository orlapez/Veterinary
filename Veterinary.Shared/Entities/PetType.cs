using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Text;

namespace Veterinary.Shared.Entities
{
    public class PetType
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de Mascota")]
        [MaxLength(50, ErrorMessage = "The field must be a maximum 50 characters.")]

        [Required(ErrorMessage = "The field {0} is required.")]
        public string Name { get; set; }


    }
}
