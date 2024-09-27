using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinary.Shared.Entities
{
    public class History
    {

        public int Id { get; set; }

        [Display(Name = "Descripción")]
        [Required]
        [MaxLength(100, ErrorMessage = "EL nombre debe ser menor a 100 caracteres")]
        public string Description { get; set; }


        [Display(Name = "Fecha")]
        [Required]
        [DisplayFormat(DataFormatString ="{0:yyyy/MM/dd HH:mm}",ApplyFormatInEditMode =true)]
        public DateTime DateLocal=> DateLocal.ToLocalTime();

        [Display(Name = "Observacion y/o Comentarios")]
        [MaxLength(100, ErrorMessage = "EL nombre debe ser menor a 100 caracteres")]
        public string Remarks { get; set; }

        public ServiceType ServiceType { get; set; }    

        public Pet Pet { get; set; }



    }
}
