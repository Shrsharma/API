using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Data
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SubjectModel> SubjectModel { get; set; }
        public DbSet<StudentModel> StudentModel { get; set; }
        public DbSet<ClassModel> ClassModel { get; set; }
    }
}
