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

        public int BoklånId { get; set; }

        [Required]
        public bool Utlånad { get; set; }

        public DateTime? LåneDatum { get; set; }

        public DateTime? ReturDatum { get; set; }


        //FK
       
        public int LånekortId { get; set; }


        public int SaldoId { get; set; }

        public Låntagare Låntagare { get; set; }

        public Saldo Saldo { get; set; }

        public bool Inlämnad
        {
            get
            {

                return ReturDatum != null;
            }

        
        }

    }

}

      
