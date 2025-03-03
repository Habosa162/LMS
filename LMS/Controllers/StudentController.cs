using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LMS.Models.StudentModels;

namespace LMS.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepo;

        public StudentController(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }

        //Get All Courses
        //Search for course by name
        //Search for course by category

        //Get Certificate for a course when finish all course lessons
        //Get All his Certificates

        //add note to a lesson in a course 
        //get all notes  
        //update note
        //delete note

        //purchase for a course
        //get all his purchases

        //add review&rating to course
        //update 
        //delete
        //get all

        //Get Enrolled Courses
        //add
        //update
        //delete

        //get all lessons in course 
        //add to StudentStudiedLesson once click on the lesson
        
        //add to wishlist
        //get all wishlist
        //delete from wishlist


    }
}
