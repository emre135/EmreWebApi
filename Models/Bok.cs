using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmreWebApi.Models
{
    public class Bok
    {
        [Key]
        [Required]
        public int Bok_Id { get; set; }

        [Required]
        public int Isbn { get; set; }

        [Required]
        public string BokTitel { get; set; }



        [Range(1, 5,
        ErrorMessage = "Betyget måste vara mellan 1-5")]
        public int Betyg { get; set; }

        public int? UtgivningsÅr { get; set; }


        //FK, NAV

        public int BoklånId { get; set; }

        public int BokFörfattaresId { get; set; }

        public List<Boklån> Boklåns { get; set; }

        public List<BokFörfattare> BokFörfattares { get; set; }

       

        }

   
}
