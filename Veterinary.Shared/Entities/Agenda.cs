using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Veterinary.Shared.Entities
{
    public class Agenda
    {

        public int Id { get; set; }

        [Display(Name = "Fecha cita")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }


        [Display(Name = "Observaciones y/o Anotaciones")]

        public string Remarks { get; set; }


        [Display(Name = "¿Está disponible?")]

        public bool IsAvailable { get; set; }

        [JsonIgnore]
        public Pet Pet { get; set; }

        [JsonIgnore]
        public Owner Owner { get; set; }



    }
}
