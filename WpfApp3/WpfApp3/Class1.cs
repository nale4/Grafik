using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace WpfApp3
{

    public class ApplicationContext : DbContext
    {
        public DbSet<Temperature> Temperature { get; set; } = null!;
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-65N15F5;Database=temp;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
    

    public class Temperature
    {
        [Required]
        public int id { get; set; }
        public int? count { get; set; }
    }
}
