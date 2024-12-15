using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1
{
    public class UniversityContext : DbContext
    {
        public UniversityContext()
        {
        }

        public DbSet<StudentEntity> Students { get; set; }
    }
}
