using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_API_CRUD.Models.Data {
    public class DataBaseContext : DbContext {

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        public DbSet<Pizza> Pizzas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuiler) {
            modelBuiler.Entity<Pizza>().ToTable("pizza");
        }

    }
}
