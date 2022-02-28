using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomDbEfCoreLab
{
    internal class ClassContext : DbContext 
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.\sqlexpress;Database=ClassroomLab;Integrated Security=SSPI");
        }

    }
}
