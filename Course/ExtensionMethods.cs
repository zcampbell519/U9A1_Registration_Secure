using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Courses
{
    public static class ExtensionMethods
    {
        public static int Validate(this Course course, int credit)
        {
            
            if (course.IsRegistered)
            {
                return -2;
            }
            if (credit + course.Credits > 9)
            {
                return -1;
            }
            return 0;
        }

        public static ListViewItem ToListItem(this Course course)
        {
            return new ListViewItem(course.CourseNumber);
        }

        public static ListViewItem[] ToListItemArray(this IEnumerable<Course> courses)
        {
            ListViewItem[] listViewItems = new ListViewItem[courses.Count()];
            for (var i = 0; i < listViewItems.Length; i++)
            {
                listViewItems[i]=new ListViewItem(courses.ElementAt(i).CourseNumber);
            }

            return listViewItems;

        }

        public static void WriteRegistrationFile(this List<Course> courses, string filename)
        {
            var fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            var sw = new StreamWriter(fs);

            foreach(Course c in courses)
            {
                if (c.IsRegistered)
                {
                    sw.WriteLine(c.ToString());
                }
            }
            sw.Close();
        }
    }
}
