using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;


namespace AssignmentThree_N01458977.Controllers
{
    public class TeacherController : Controller
    {
        // GET: /Teacher/Index
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Returns list of teacher names from database.
        /// <example> /Teacher/List </example>
        /// </summary>
        /// <param></param>
        /// <return>List of all teacher names</return>
        public ActionResult List()
        {
            TeacherDataController controller = new TeacherDataController();
            ViewBag.ListTeachers = controller.ListTeachers();

            return View();
        }

        /// <summary>
        /// Returns selected teacher name.
        /// <example> 6/Teacher/Show?id=2 </example>
        /// </summary>
        /// <param>?id=2</param>
        /// <return>Selected Teachers name</return>
        public ActionResult Show(int? id)
        {
            Models.Teacher NewTeacher = new Models.Teacher();

            if (id == null) NewTeacher = null;
            else
            {
                TeacherDataController controller = new TeacherDataController();
                NewTeacher = controller.ShowTeacher((int)id);
            }

            return View(NewTeacher);
        }

        /// <summary>
        /// Shows info on the teacher that can be deleted.
        /// <example> /Teacher/DeleteConfirm </example>
        /// </summary>
        /// <param></param>
        /// <return>Routes back to selected teacher if canceled.</return>
        public ActionResult DeleteConfirm(int? id)
        {
            Models.Teacher NewTeacher = new Models.Teacher();

            if (id == null) NewTeacher = null;
            else
            {
                TeacherDataController controller = new TeacherDataController();
                NewTeacher = controller.ShowTeacher((int)id);
            }

            return View(NewTeacher);
        }

        /// <summary>
        /// Deletes Selected Teacher
        /// <example> /Teacher/List </example>
        /// </summary>
        /// <param></param>
        /// <return>Routes back to Teacher list.</return>
        //POST : /Teacher/Delete/{id}
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteAuthor(id);
            return RedirectToAction("List");
        }

        /// <summary>
        /// Shows new teacher form.
        /// <example> /Teacher/List </example>
        /// </summary>
        /// <param></param>
        /// <return>Teacher list page</return>
        //GET : /Teacher/New
        public ActionResult New()
        {
            return View();
        }

        /// <summary>
        /// Adds new teacher to the database database.
        /// <example> /Teacher/List </example>
        /// </summary>
        /// <param></param>
        /// <return>List of all teacher names</return>
        //POST : /Teacher/Create
        public ActionResult Create(string TeacherFname, string TeacherLname, float Salary)
        {
            //Identify this method is running
            //Identify the inpiuts provided from the form 

            Debug.WriteLine(TeacherFname);
            Debug.WriteLine(TeacherLname);
            Debug.WriteLine(Salary);

            Models.Teacher NewTeacher = new Models.Teacher();
            NewTeacher.TeacherFname = TeacherFname;
            NewTeacher.TeacherLname = TeacherLname;
            NewTeacher.Salary = Salary;

            TeacherDataController controller = new TeacherDataController();
            controller.AddTeacher(NewTeacher);

            return RedirectToAction("List"); 
        }

         
    }
}