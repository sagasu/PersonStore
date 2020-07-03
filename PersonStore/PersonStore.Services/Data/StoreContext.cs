using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PersonStore.Services.Data.Model;

namespace PersonStore.Services.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
    }
}
