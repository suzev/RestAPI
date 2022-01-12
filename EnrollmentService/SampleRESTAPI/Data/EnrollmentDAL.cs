﻿using Microsoft.EntityFrameworkCore;
using SampleRESTAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleRESTAPI.Data
{
    public class EnrollmentDAL : IEnrollment
    {
        private ApplicationDbContext _db;
        public EnrollmentDAL(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Enrollment>> GetAll()
        {
            var results = await _db.Enrollments.Include(e=>e.Student).Include(e=>e.Course).AsNoTracking().ToListAsync();
            return results;
        }

        public Task<Enrollment> GetById(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Enrollment> Insert(Enrollment obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<Enrollment> Update(string id, Enrollment obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
