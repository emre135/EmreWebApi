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
        public DbSet<Boklån> Boklån { get; set; }
        public DbSet<Låntagare> Låntagare { get; set; }



    }
}
