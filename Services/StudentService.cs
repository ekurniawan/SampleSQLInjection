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

        public async Task<Student> GetById(string id)
        {
            //var result = await _db.Students.Where(s => s.StudentID == Convert.ToInt32(id))
            //    .AsNoTracking().SingleOrDefaultAsync();
            var result = await (from s in _db.Students
                                where s.StudentID == Convert.ToInt32(id)
                                select s).AsNoTracking().SingleOrDefaultAsync();

            return result;
        }

        public async Task<IEnumerable<Student>> GetByName(string name)
        {
            //var lmdResults = await _db.Students.Where(s => s.FirstMidName.Contains(name) || 
            //    s.LastName.Contains(name)).AsNoTracking().ToListAsync();
            var results = await (from s in _db.Students
                                 where s.FirstMidName.Contains(name) || s.LastName.Contains(name)
                                 select s).AsNoTracking().ToListAsync();

            return results;
        }
    }
}
