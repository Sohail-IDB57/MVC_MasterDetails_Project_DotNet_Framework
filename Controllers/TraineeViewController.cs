using MVCProject_1280293.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject_1280293.Controllers
{
    public class TraineeViewController : Controller
    {
        public ApplicationDbContext db= new ApplicationDbContext();
        // GET: TraineeView
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getCourseCategories()
        {
            List<CourseCategory> categories = new List<CourseCategory>();
            categories = db.CourseCategories.OrderBy(a => a.CategoryName).ToList();
            return new JsonResult { Data = categories, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
       
        public JsonResult getCourse(int courseCategoryId)
        {
            List<Course> courses = new List<Course>();
            courses = db.Courses.Where(b => b.CourseCategoryId.Equals(courseCategoryId)).OrderBy(cn => cn.CourseName).ToList();
            return new JsonResult { Data = courses, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

       
        public JsonResult Save(Trainee trainee, HttpPostedFileBase file)
        {
            bool status = false;


            if (file != null /*&& file.ContentLength > 0*/)
            {
                string folderPath = Server.MapPath("~/Images/");
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string filePath = Path.Combine(folderPath, fileName);
                file.SaveAs(filePath);
                trainee.Image = fileName;
            }

            var isValidModel = TryUpdateModel(trainee);
            if (isValidModel)
            {
                db.Trainees.Add(trainee);
                db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }
       
    }
}