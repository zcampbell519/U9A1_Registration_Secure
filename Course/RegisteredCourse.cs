using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Courses
{
    [Table("selected_course")]
    public class RegisteredCourse
    {
        public RegisteredCourse()
        {

        }

        public RegisteredCourse(string userId, string courseNumber)
        {
            UserId = userId;
            CourseNumber = courseNumber;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("selectedid")]
        public Int64 SelectedId { get; set; }
        [Column("courseNumber")]
        public string CourseNumber { get; set; }
        [Column("userid")]
        public string UserId { get; set; }
    }
}
