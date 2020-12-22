using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmreWebApi.Models
{
    public class Författare
    {

        [Key]
        public int FörfattareId { get; set; }

        [Required]
        public string Författarenamn { get; set; }

        public List<BokFörfattare> BokFörfattares { get; set; }

    }
}
