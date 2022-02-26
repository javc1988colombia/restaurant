using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace backend.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<meals> meals { get; set; }
        public virtual DbSet<users> users { get; set; }
        public virtual DbSet<ingredients> ingredients { get; set; }
        public virtual DbSet<meals_ingredients> meals_ingredients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<meals>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<users>()
                .Property(e => e.email)
                .IsFixedLength();

            modelBuilder.Entity<users>()
                .Property(e => e.password)
                .IsFixedLength();

            modelBuilder.Entity<ingredients>()
                .Property(e => e.name)
                .IsFixedLength();
        }
    }
}
