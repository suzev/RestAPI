﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentService.Models
{
    //[Table("Course")]
    public class Course
    {
        public int CourseID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public int Credits { get; set; }

        [Required]
        public double Price { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }



    }
}
