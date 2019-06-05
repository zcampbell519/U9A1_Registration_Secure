using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Courses
{
    [Table("course")]
    public class Course
    {
        
        // Parameterized constructor sets values for all properties
        public Course(string courseNumber, string courseTitle, int credits, int weeks)
        {
            CourseNumber = courseNumber;
            CourseTitle = courseTitle;
            Credits = credits;
            LengthInWeeks = weeks;
            // Initialize IsRegistered to false
            IsRegistered = false;
        }
        public Course() { }

        // These properties are auto-implemented and read only.
        // Mark the Key
        [Key]
        public string CourseNumber { get; set; }
        public string CourseTitle { get; set; }
        public int Credits { get; set; }
        public int LengthInWeeks { get; set; }
        // IsRegistered is read-write
        // Mark as unmapped property
        [NotMapped]
        public bool IsRegistered { get; set; }

        public override string ToString()
        {
            return CourseNumber.ToString() + "," + CourseTitle + "," + Credits.ToString() + "," + LengthInWeeks.ToString();
        }

        
    }
}