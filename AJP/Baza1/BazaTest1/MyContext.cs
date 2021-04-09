using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BazaTest1
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=test1;user=root;password=test");
        }
        public DbSet<ludziki> ludziki { get; set; }
        public DbSet<adres> adres { get; set; }


    }
    public class ludziki
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [StringLength(50)] public string imie { get; set; }
        [StringLength(100)] public string nazisko { get; set; }
        public DateTime? dataUrodzenia { get; set; }

    }
    public class adres
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int ludzik { get; set; }
        [StringLength(200)] public string aders { get; set; }

        [ForeignKey("ludzik")]
        public ludziki ludzik1 { get; set; }


    }

}
