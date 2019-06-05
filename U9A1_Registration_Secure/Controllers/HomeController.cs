using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using U9A1_Registration_Secure.Models;
using Courses;

namespace U9A1_Registration_Secure.Controllers
{
    public class HomeController : Controller
    {
        private RegistrationModel viewModel = new RegistrationModel();

        private void generateCourseList()
        {
            viewModel.CourseListItems = new List<SelectListItem>();


            foreach (Course c in viewModel.Courses.ToList())
            {
                SelectListItem item = new SelectListItem();
                item.Text = c.CourseTitle;
                item.Value = c.CourseNumber;
                viewModel.CourseListItems.Add(item);
            }

            viewModel.TotalCredits = calculateTotalCredit();
        }

        private int calculateTotalCredit()
        {
            var selectedCourseCredit = viewModel.RegisteredCourses
                .Join(viewModel.Courses, rc => rc.CourseNumber, c => c.CourseNumber, (rc, c) => c.Credits);

            if (selectedCourseCredit.Count() > 0)
            {
                return selectedCourseCredit.Sum();
            }
            else
            {
                return 0;
            }


        }

        public ActionResult Index()
        {
            viewModel.UserMessage = "Please select a course";
            generateCourseList();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(RegistrationModel registrationModel)
        {
            if (!String.IsNullOrWhiteSpace(registrationModel.UserIdText))
            {
                viewModel.CourseListItems = new List<SelectListItem>();
                if (registrationModel.SelectedCourseNumber != null)
                {
                    viewModel.SelectedCourseNumber = registrationModel.SelectedCourseNumber;
                    viewModel.UserIdText = registrationModel.UserIdText;

                    Course selectedCourse = viewModel.Courses.Where(c => c.CourseNumber == viewModel.SelectedCourseNumber).Single();
                    generateCourseList();
                    if (!(viewModel.TotalCredits + selectedCourse.Credits > 9))
                    {


                        if (!viewModel.RegisteredCourses.Select(c => c.CourseNumber).Contains(selectedCourse.CourseNumber))
                        {
                            viewModel.RegisteredCourses.Add(new RegisteredCourse(viewModel.UserIdText, viewModel.SelectedCourseNumber));
                            viewModel.SaveChanges();
                            viewModel.UserMessage = $"{selectedCourse.CourseNumber} registered!";
                        }
                        else
                        {
                            viewModel.UserMessage = "Cannot select same course more than once.";
                        }
                    }
                    else
                    {
                        viewModel.UserMessage = "Cannot register for more than 9 credits!";
                    }
                }
                else
                {
                    viewModel.UserMessage = "Please select a course";
                }
                generateCourseList();
                return View(viewModel);
            }
            else
            {
                viewModel.UserMessage = "Please enter user id.";
                generateCourseList();
                return View(viewModel);
            }

        }


        public ActionResult DeleteAll(RegistrationModel registrationModel)
        {
            foreach (var rc in viewModel.RegisteredCourses.ToList())
            {
                viewModel.RegisteredCourses.Remove(rc);
                viewModel.SaveChanges();
            }
            viewModel.UserMessage = "All courses deleted!";
            generateCourseList();
            return View("Index", viewModel);
        }
    }
}