using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Veterinary.Shared.Entities
{
    public  class Pet
    {


        public int Id { get; set; }

        [Display(Name = "Nombre mascota")]
        [Required]
        [MaxLength(50, ErrorMessage = "EL nombre debe ser menor a 50 caracteres")]
        public string Name { get; set; }

        [Display(Name = "Foto mascota")]
        public string  ImageUrl { get; set; }

        [Display(Name = "Raza")]
        [Required]
        [MaxLength(50, ErrorMessage = "EL nombre debe ser menor a 50 caracteres")]
        public string Race { get; set; }

        [Display(Name = "Born")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Born { get; set; }

        [Display(Name = "Observacion y/o Comentarios")]
        [MaxLength(100, ErrorMessage = "EL nombre debe ser menor a 100 caracteres")]
        public string Remarks { get; set; }

        [JsonIgnore]
        public ICollection<History> Histories { get; set; }

        [JsonIgnore]
        public Owner Owners { get; set; }
       public int OwnerId { get; set; }

        [JsonIgnore]
         public PetType PetTypes { get; set; }
        public int PetTypeId { get; set; }

        [JsonIgnore]

        public ICollection<Agenda> Agendas { get; set; }



    }
}
