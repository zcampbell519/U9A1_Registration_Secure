namespace U9A1_Registration_Secure.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using Courses;

    public class RegistrationModel : DbContext
    {
        // Your context has been configured to use a 'RegistrationModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'U9A1_Registration_Secure.Models.RegistrationModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'RegistrationModel' 
        // connection string in the application configuration file.
        public RegistrationModel()
            : base("name=RegistrationModelConnString")
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<RegisteredCourse> RegisteredCourses { get; set; }

        public List<SelectListItem> CourseListItems { get; set; }
        public string SelectedCourseNumber { get; set; }
        public string UserIdText { get; set; }
        public string UserMessage { get; set; }
        public int TotalCredits { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}