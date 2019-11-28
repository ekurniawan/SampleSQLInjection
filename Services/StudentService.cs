using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleASPCore.Models;

namespace SampleASPCore.Services
{
    public class StudentService : IStudent
    {
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

        public Task<IEnumerable<Student>> GetAll()
        {
            throw new NotImplementedException();
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
