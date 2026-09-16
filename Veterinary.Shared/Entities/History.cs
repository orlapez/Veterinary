using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Veterinary.Shared.Entities
{
    public class History
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "The field is mandatory.")]
        public string Description { get; set; }


        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public string Remarks { get; set; }


        //Foranea enviada desde la tabla Pet
        public int PetId { get; set; }

        [JsonIgnore]
        public Pet Pet { get; set; }


        //Foranea enviada desde la tabla ServiceType
        public int ServiceTypeId { get; set; }

        [JsonIgnore]
        public ServiceType ServiceType { get; set; }



    }
}
