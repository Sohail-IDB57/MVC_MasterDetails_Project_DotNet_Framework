using MVCProject_1280293.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;

namespace MVCProject_1280293.DAL
{
    public class SeedClass
    {
        public void Seed(ApplicationDbContext context)
        {
            context.Courses.AddOrUpdate(
                s => s.CourseName,
                new Course { CourseName = "C Sharf", CourseCategoryId =1, Duration = "3 Month" , CourseFee= 8000},
                new Course { CourseName = "PHP", CourseCategoryId = 1, Duration = "3 Month", CourseFee = 5000 },
                new Course { CourseName = "Java", CourseCategoryId = 1, Duration = "3 Month", CourseFee = 6000 },
                new Course { CourseName = "Phyton", CourseCategoryId = 1, Duration = "3 Month", CourseFee = 5000 }
                );
        }
    }
}