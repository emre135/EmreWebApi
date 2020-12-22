using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmreWebApi.Models
{
    public class Saldo
    {

        [Key]
        public int SaldoId { get; set; }
        public int BokId { get; set; }
        public Bok Bok { get; set; }

        public List<Boklån> Boklåns { get; set; }

        public bool Tillgänglig
        {
            get
            {

                if (Boklåns == null)
                    return true;

                else if (Boklåns.Count == 0)
                    return true;

                else if (Boklåns.All(r => r.Inlämnad))
                    return true;

                else
                {
                    return false;
                }
            }
        }
    }
}
