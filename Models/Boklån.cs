using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmreWebApi.Models
{
    public class Boklån
    {

        [Key]
        [Required]
   
        public int Boklån_Id { get; set; }

        [Required]
        public bool Utlånad { get; set; }

        public DateTime? LåneDatum { get; set; }

        public DateTime? ReturDatum { get; set; }


        //FK
        public int BokId { get; set; }
        public int LåntagareId { get; set; }
    }
}

