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



        [Display(Name = "Name")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Name { get; set; }


        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Breed { get; set; }

        [Display(Name = "Born")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Born { get; set; }

        [Display(Name = "Comentarios y/o Observaciones")]
        [MaxLength(300,ErrorMessage ="Este campo solo permite 300 caracteres")]
        public string Remarks { get; set; }

        //Recibe llave foranea de Owner (OwnerId)

        [JsonIgnore]
        public Owner Owner { get; set; }


        public int OwnerId { get; set; }


        //Recibe llave foranea de PetType (PetTypeId)

        [JsonIgnore] //ignora el resto de atributos de la entidad PetType , y solo envia su Id
        public PetType PetType { get; set; }

        public int PetTypeId { get; set; }

        //Envia foranea a History
        public ICollection<History> Histories { get; set; }



    }
}
