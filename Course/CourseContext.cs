using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Courses
{
    public class CourseContext : DbContext
    {
        public CourseContext() : base("name=registrationEntities") { }
        public DbSet<Course> Courses { get; set; }
        public DbSet<RegisteredCourse> RegisteredCourses { get; set; }
    }
}
