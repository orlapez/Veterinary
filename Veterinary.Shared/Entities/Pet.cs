using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Veterinary.Shared.Entities
{
    public class Pet
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field is mandatory.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field  is mandatory.")]

        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "The field is mandatory.")]

        public string Breed { get; set; }

        [Required(ErrorMessage = "The field is mandatory.")]

        [DataType(DataType.Date)]

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime BirthDate { get; set; }


        [DataType(DataType.MultilineText)]
           
      
        public string Remarks { get; set; }

        public int PetTypeId { get; set; }

        [JsonIgnore]
        public PetType PetType { get; set; }


        public int OwnerId { get; set; }

        [JsonIgnore]
        public Owner Owner { get; set; }


        public ICollection<History>Histories { get; set; }

        public ICollection<Agenda> Agendas { get; set; }



    }
}
