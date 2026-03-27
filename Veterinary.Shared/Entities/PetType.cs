using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Veterinary.Shared.Entities
{
    public class PetType
    {

        public int Id { get; set; }

        [Display(Name = "Tipo de mascota")]
        [Required(ErrorMessage = "The document field is required.")]
        [MaxLength(20, ErrorMessage = "The Name field can not have more than 20 characters.")]

        public string Name { get; set; }


        //Envia su foranea a Pet
        public ICollection <Pet> Pets { get; set; }
    }
}
