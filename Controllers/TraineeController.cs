using MVCProject_1280293.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCProject_1280293.Controllers
{
    public class TraineeController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Trainee
        public ActionResult Index()
        {
            return View(_db.Trainees.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainee trainnee = _db.Trainees.Find(id);
            if (trainnee == null)
            {
                return HttpNotFound();
            }
            return View(trainnee);
        }

        public JsonResult CourseDetails(int id)
        {
            var courseDetails = _db.TraineesDetail.Where(o => o.TraineeId == id).ToList();

            var courseInfo = courseDetails
                    .Select(o => new {
                       id = o.TraineeId,
                       courseId = o.CourseId,
                       courseName = _db.Courses.FirstOrDefault(p => p.CourseId == o.CourseId)?.CourseName,
                       duration = o.Duration,
                       courseFee = o.CourseFee.ToString()
                    });
            return Json(courseInfo, JsonRequestBehavior.AllowGet);
        }

        // Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainee trainee = _db.Trainees.Find(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            return View(trainee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trainee trainee = _db.Trainees.Find(id);
            _db.Trainees.Remove(trainee);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainee trainee = _db.Trainees.Find(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            return View(trainee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TraineeId,TraineeName,FatherName,Gender,DateOfBirth,Address,Email,Image")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(trainee).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainee);
        }

    }
}