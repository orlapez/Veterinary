using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Veterinary.Shared.Entities
{
   public  class Agenda
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public string Remarks { get; set; }

        [Display(Name = "¿Disponible?")]
        public bool IsAvailable { get; set; }

        public int OwnerId { get; set; }

        [JsonIgnore]

        public Owner Owner { get; set; }


        public int PetId { get; set; }

        [JsonIgnore]
        public Pet Pet { get; set; }




    }
}
