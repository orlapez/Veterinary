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


        [Display(Name = "Description")]
        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Description { get; set; }

        [Display(Name = "Date*")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public string Remarks { get; set; }


        [Display(Name = "Date*")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateLocal => Date.ToLocalTime();

        //Recibe foranea de ServiceType (ServiceTypeId)

        [JsonIgnore]
        public ServiceType ServiceType { get; set; }

        public int ServiceTypeId { get; set; }

        //Recibe foranea de Pet ((PetId)
        [JsonIgnore]

        public Pet Pet { get; set; }

        public int PetId { get; set; }

    }
}


