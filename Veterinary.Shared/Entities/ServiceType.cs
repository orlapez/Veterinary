using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Veterinary.Shared.Entities
{
    public class ServiceType
    {

        public int Id { get; set; }

        [Display(Name = "Tipo de servicio")]
        [Required(ErrorMessage = "The document field is required.")]
        [MaxLength(20, ErrorMessage = "The Name field can not have more than 20 characters.")]

        public string Name { get; set; }

        // Envia su foranea a History
        public ICollection<History> Histories { get; set; }
    }
}
