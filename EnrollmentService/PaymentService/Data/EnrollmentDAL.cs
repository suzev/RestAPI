using PaymentService.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentService.Data
{
    public class EnrollmentDAL : IEnrollment
    {
        private readonly Kasus1Context _db;

        public EnrollmentDAL (Kasus1Context db)
        {
            _db = db;
        }
        public async Task CreateEnrollment(Enrollment enrollment)
        {
            if (enrollment == null) throw new ArgumentNullException(nameof(enrollment));
            _db.Enrollments.Add(enrollment);
            await _db.SaveChangesAsync();
        }
    }
}
