using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinary.Shared.Entities
{
 public class Owner
    {
        //Primary key
        //Autonumeric
        
        public int Id { get; set; }


        [Display(Name="Nombre propietario")]
        [Required]
        [MaxLength(50)]
        public string FirstName{ get; set; }

        [Display(Name = "Apellido    propietario")]
        [Required]
        [MaxLength(50)]

        public string LastName { get; set; }

        [Display(Name = "Documento de identidad")]
        [Required]
        [MaxLength(13,ErrorMessage ="El documento de identidad no puede superar los 13 caracteres")]
        public string Documento { get; set; }

        [Display(Name = "Teléfono fijo")]
        [Required]
        [MaxLength(10, ErrorMessage = "El telefono fijo no puede superar los 10 caracteres")]
        public string FixedPhone { get; set; }

        [Display(Name = "Teléfono móvil")]
        [Required]
        [MaxLength(10, ErrorMessage = "El telefono móvil no puede superar los 10 caracteres")]
        public string CellPhone { get; set; }

        // =>  expresión Lambda
        // $ interpolación de cadenas
       public string FullName =>$"{FirstName} {LastName}";



    }
}
