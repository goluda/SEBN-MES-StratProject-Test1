using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Materialy.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Materialy
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=materialy;user=root;password=test");
        }
        public DbSet<Material> Material { get; set; }
        public DbSet<Routing> Routing { get; set; }
        public DbSet<Bom> Bom { get; set; }

    }
    [Table("bom")]
    public class Bom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MaterialNo { get; set; }
        public string ComponentNo { get; set; }
        public int Qty { get; set; }
        [ForeignKey("ComponentNo")]
        public Material material { get; set; }

        [NotMapped]
        public MaterialyController.CompleteMaterial SubMaterial { get; set; }
    }

    public class Routing
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MaterialNo { get; set; }
        public string Description { get; set; }
        public int Time { get; set; }
    }
    [Table("material")]
    public class Material
    {
        [Key]
        public string MaterialNo { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

    }

}
