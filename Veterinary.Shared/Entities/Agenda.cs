using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Veterinary.Shared.Entities
{
    public class Agenda
    {
        public int Id { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd H:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }


        [Display(Name = "Comentario y/o Observaciones")]
        public string Remarks { get; set; }

        [Display(Name = "Is Available?")]

        // True -- False
        public bool IsAvailable { get; set; }


        //Recibe foranea de Pet ((PetId)
        [JsonIgnore]

        public Pet Pet { get; set; }

        public int PetId { get; set; }


        //Recibe foranea de Owner (OwnerId)
        [JsonIgnore]
        public Owner Owner { get; set; }

        public int OwnerId { get; set; }

    }
}
