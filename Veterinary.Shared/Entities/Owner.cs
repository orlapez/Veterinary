using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Veterinary.Shared.Entities
{
    public class Owner
    {
        public int Id { get; set; }

        [Display(Name = "Documento de Identidad")]
        [MaxLength(10, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Document { get; set; }


        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo FirstName debe tener una logitud de 50")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        
        public string FirstName { get; set; }  
        
        [Display(Name = "Apellido")]
        [MaxLength(50, ErrorMessage = "El campo LastName debe tener una longitud de 50")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string LastName { get; set; }


        [Display(Name = "Teléfono Fijo")]
        [MaxLength(10, ErrorMessage = "El campo Telefono debe tener una logitud de 10")]
      
        public string FixedPhone { get; set; }

        [Display(Name = "Teléfono Celular")]
        [MaxLength(10, ErrorMessage = "El campo Celular debe tener una logitud de 10")]
        public string CellPhone { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(100, ErrorMessage = "El campo Address debe tener una longitud de 100")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Address { get; set; }


        public string FullName => $"{FirstName} {LastName}";    

    }



    }

