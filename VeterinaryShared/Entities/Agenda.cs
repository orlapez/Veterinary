using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Veterinary.Shared.Entities
{
    public class Agenda
    {

        public int Id { get; set; }

        [Display(Name = "Fecha")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateLocal => DateLocal.ToLocalTime();
        public DateTime Date { get; set; }

        public string Remarks { get; set; }


        [Display(Name = "¿Está disponible?")]
        public bool IsAvailable{ get; set; }

        [JsonIgnore]
        public Pet Pet { get; set; }
        public int PetId { get; set; }

        [JsonIgnore]
        public Owner Owner { get; set; }

        public int OwnerId { get; set; }

    }
}
