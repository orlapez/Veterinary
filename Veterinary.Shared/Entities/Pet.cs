using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Veterinary.Shared.Entities
{
    public class Pet
    {

        public int Id { get; set; }



        [Display(Name = "Nombre mascota")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Display(Name = "foto mascota")]

        public string ImageUrl { get; set; }

        [Display(Name = "Raza")]
        [Required]
        [MaxLength(50)]
        public string  Race { get; set; }



        [Display(Name = "Fecha nacimiento")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Born { get; set; }

        [Display(Name = "Edad")]
        [Required]
        public int Age { get; set; }

        [Display(Name = "Observaciones y/o Anotaciones")]

        public string Remarks { get; set; }

        [JsonIgnore]
        public ICollection<History> Histories { get; set; }


        [JsonIgnore]

        public ICollection<Agenda> Agenda { get; set; }

        [JsonIgnore]

        public Owner Owner { get; set; }

        public int OwnerId { get; set; }

        [JsonIgnore]

        public PetType PetType { get; set; }


        public int PetTypeId { get; set; }


    }
}
