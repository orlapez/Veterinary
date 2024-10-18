using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinary.Shared.Enums;

namespace Veterinary.Shared.Entities
{
public  class User:IdentityUser
    {

        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo 20 caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Document { get; set; }

        [Display(Name = "Nombres")]
        [MaxLength(50, ErrorMessage = "El campo {1} debe tener máximo 50 caractéres.")]
        [Required(ErrorMessage = "El campo {1} es obligatorio.")]
        public string FirstName { get; set; } 

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {2} debe tener máximo 50 caractéres.")]
        [Required(ErrorMessage = "El campo {2} es obligatorio.")]
        public string LastName { get; set; } 

        [Display(Name = "Foto")]
        public string Photo { get; set; }

        [Display(Name = "Tipo de usuario")]
        public UserType UserType { get; set; } //Enum


   
    }
}
