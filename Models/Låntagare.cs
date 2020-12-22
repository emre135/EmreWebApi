using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmreWebApi.Models
{
    public class Låntagare
    {

        [Key]
        [Required]

        public int LånekortId { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Förnamn { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Efternamn { get; set; }
        
        public List<Boklån> Boklåns { get; set; }

        

        
    }
}
