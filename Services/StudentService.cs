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

        public async Task Create(Student obj)
        {
            try
            {
                _db.Add(obj);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Delete(string id)
        {
            var deleteData = await GetById(id);
            if (deleteData != null)
            {
                try
                {
                    _db.Remove(deleteData);
                    await _db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error: {ex.Message}");
                }
            }
        }

        public async Task Edit(Student obj)
        {
            try
            {
                var editData = await GetById(obj.StudentID.ToString());
                if (editData != null)
                {
                    _db.Update(editData);
                    await _db.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Data tidak ditemukan");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
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
            //var result = await (from s in _db.Students
            //                    where s.StudentID == Convert.ToInt32(id)
            //                    select s).AsNoTracking().SingleOrDefaultAsync();


            //var model = await _db.Students.AsNoTracking().FirstOrDefaultAsync(s => s.StudentID == Convert.ToInt32(id));
            var result = await (from s in _db.Students
                                 where s.StudentID == Convert.ToInt32(id)
                                 select s).AsNoTracking().SingleOrDefaultAsync();

            var enrollment = await (from e in _db.Enrollments.Include(e => e.Course)
                                    where e.StudentID == Convert.ToInt32(id)
                                    select e).AsNoTracking().ToListAsync();

            result.Enrollments = enrollment;

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
