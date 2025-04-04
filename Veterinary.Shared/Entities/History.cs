using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Veterinary.Shared.Entities
{
    public class History
    {

        public int Id { get; set; }



        [Display(Name = "Descripción")]
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }


        [Display(Name = "Fecha historia")]
        [Required]
        [DisplayFormat(DataFormatString ="{0:yyyy/MM/dd HH:mm}",ApplyFormatInEditMode =true)]
        public DateTime Date { get; set; }



        [Display(Name = "Observaciones y/o Anotaciones")]

        public string Remarks { get; set; }



        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateLocal =>Date.ToLocalTime();

        [JsonIgnore]
        public Pet Pet { get; set; }


        [JsonIgnore]
        public ServiceType ServiceType { get; set; }

    }
}
