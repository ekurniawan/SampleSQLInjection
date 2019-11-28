using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleASPCore.Data;
using SampleASPCore.Models;

namespace SampleASPCore.Services
{
    public class StudentService : IStudent
    {
        private ApplicationDbContext _db;
        public StudentService(ApplicationDbContext db)
        {
            _db = db;
        }
        public Task Create(Student obj)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task Edit(Student obj)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            //var results = await _db.Students.OrderBy(s => s.FirstMidName).ToListAsync();
            var results = await (from s in _db.Students
                           orderby s.FirstMidName ascending
                           select s).AsNoTracking().ToListAsync();
           
            return results;
        }

        public Task<Student> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
