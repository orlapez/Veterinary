using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Veterinary.Shared.Entities
{
    public class ServiceType
    {
        public int Id { get; set; }

        [Display(Name = "Service Type Name")]
        [Required(ErrorMessage = "The field {0} is required.")]
        [MaxLength(100, ErrorMessage = "The field must be a maximum 100 characters.")]
        public string Name { get; set; }
    }
}
