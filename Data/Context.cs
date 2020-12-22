using EmreWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmreWebApi.Data
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Bok> Böcker { get; set; }
        public DbSet<Boklån> Boklåns { get; set; }
        public DbSet<Låntagare> Låntagares { get; set; }

        public DbSet<Författare> Författares { get; set; }

        public DbSet<Saldo> Saldos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {

          //  var cascadeFKs = modelbuilder.Model.GetEntityTypes()
            //    .SelectMany(t => t.GetForeignKeys())
              //  .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

          //  foreach (var fk in cascadeFKs)
            //    fk.DeleteBehavior = DeleteBehavior.Restrict;

            modelbuilder.Entity<BokFörfattare>()
                .HasKey(sc => new { sc.BokId, sc.FörfattareId });

            modelbuilder.Entity<BokFörfattare>()
                .HasOne(sc => sc.Bok)
                .WithMany(s => s.BokFörfattares)
                .HasForeignKey(sc => sc.FörfattareId);
                


            modelbuilder.Entity<BokFörfattare>()
                .HasOne(sc => sc.Författare)
                .WithMany(c => c.BokFörfattares)
                .HasForeignKey(sc => sc.BokId);
                


        }

        public DbSet<EmreWebApi.Models.BokFörfattare> BokFörfattare { get; set; }

        public DbSet<EmreWebApi.Models.Saldo> Saldo { get; set; }
    }
}
