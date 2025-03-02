﻿using LMS.Models.InstractourModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS.Models.StudentModels
{
    public class StudentEnrollCourse
    {
            [Key]
            public int Id { get; set; }

            [ForeignKey("Student")]
            public int StudentId { get; set; }
            public AppUser Student { get; set; }

            [ForeignKey("Course")]
            public int CourseId { get; set; }
            public Course Course { get; set; }

            public DateTime EnrollmentDate { get; set; } = DateTime.Now;
        
    }
}
