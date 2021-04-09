using System;
using Microsoft.EntityFrameworkCore;

namespace BazaTestLudziki
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=test;user=root;password=test");
        }
        public DbSet<ludziki> ludziki { get; set; }


    }
    public class ludziki
    {
        public int id { get; set; }
        public string imie { get; set; }
        public string nazisko { get; set; }

    }

}
