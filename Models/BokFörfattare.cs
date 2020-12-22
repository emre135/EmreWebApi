using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmreWebApi.Models
{
    public class BokFörfattare
    {
        public int BokId { get; set; }

        public int FörfattareId { get; set; }


        public Bok Bok { get; set; }

        public Författare Författare { get; set; }

    }
}
