using System;
using System.Collections.Generic;

#nullable disable

namespace PaymentService.Models
{
    public partial class Course
    {
        public Course()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public double Price { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
