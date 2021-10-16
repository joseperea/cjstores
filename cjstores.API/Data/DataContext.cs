using cjstores.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cjstores.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }

        public DbSet<TipoDocumento> TipoDocumentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TipoDocumento>().HasIndex(x => x.Nombre_TD).IsUnique();
            modelBuilder.Entity<TipoDocumento>().HasIndex(x => x.Abreviatura).IsUnique();
        }
    }
}
