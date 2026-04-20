using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Veterinary.Shared.Entities
{
    public class Owner
    {

        
        public int Id { get; set; }

        [Display(Name = "Documento de identidad")]
        [Required(ErrorMessage = "The document field is required.")]
        [MaxLength(20, ErrorMessage = "The document field can not have more than 20 characters.")]

        public string Document { get; set; }

        [Display(Name = "Nombres")]
        //[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "The Name field can only contain letters and spaces.")]
        [Required(ErrorMessage = "FirstName field is required.")]
        [MaxLength(50, ErrorMessage = "The Name field can not have more than 20 characters.")]
        public string FirstName { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Lastname field is required.")]
        [MaxLength(50, ErrorMessage = "The Lastname field can not have more than 20 characters.")]
        public string LastName { get; set; }

        [Display(Name = "Teléfono")]
      
        [MaxLength(10, ErrorMessage = "The Phone field can not have more than 10 characters.")]
        public string FixedPhone { get; set; }

        [Display(Name = "Móvil")]
        //[RegularExpression(@"^\d{10}$", ErrorMessage = "The Cellphone field must be a 10-digit number.")]
        [Required(ErrorMessage = "The Cellphone field is required.")]
        [MaxLength(10, ErrorMessage = "The Cellphone field can not have more than 10 characters.")]

        public string CellPhone { get; set; }

        [Display(Name = "Dirección residencia")]
        [Required(ErrorMessage = "The Address field is required.")]
        [MaxLength(80,ErrorMessage = "The document field can not have more than 20 characters.")]

        public string Address { get; set; }

        public string FullName => $"{FirstName} {LastName}".TrimEnd();

        //Envia su foranea a Agenda

        [JsonIgnore]
        public ICollection<Agenda> Agendas { get; set; }

        //Envia su foranea también a Pet


        [JsonIgnore]
        public ICollection<Pet> Pets { get; set; }


    }
}
