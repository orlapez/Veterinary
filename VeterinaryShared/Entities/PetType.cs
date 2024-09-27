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

        [Display(Name = "Tipo de mascosta")]
        [Required]
        [MaxLength(50,ErrorMessage ="EL nombre debe ser menor a 50 caracteres")]
        public string Name { get; set; }





    }
}
