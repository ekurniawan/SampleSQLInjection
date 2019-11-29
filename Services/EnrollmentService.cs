using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleASPCore.Data;
using SampleASPCore.Models;

namespace SampleASPCore.Services
{
    public class EnrollmentService : IEnrollment
    {
        private ApplicationDbContext _db;
        public EnrollmentService(ApplicationDbContext db)
        {
            _db = db;
        }
        public Task Create(Enrollment obj)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task Edit(Enrollment obj)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Enrollment>> GetAll()
        {
            var models = await (from e in _db.Enrollments.Include(e => e.Student).Include(e => e.Course)
                                select e).AsNoTracking().ToListAsync();
            return models;
        }

        public Task<Enrollment> GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
