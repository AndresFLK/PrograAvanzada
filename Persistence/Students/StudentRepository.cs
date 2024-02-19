using Aplication.Contexts;
using Aplication.Students;
using Domain.Students;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Students
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly DbSet<Student> _students;

        public StudentRepository(ApplicationDbContext context)
        {
            this._context = context;
            _students = _context.Students;
        }


        public List<Student> GetAll()
        {
            return _students.ToList();
        }


        public Student Get(Expression<Func<Student, bool>> predicate)
        {
            IQueryable<Student> query = _students;
            query = query.Where(predicate);

            return query.FirstOrDefault();
        }

        public void Insert(Student student)
        {
            _students.Add(student);
        }

        public void Update(Student student)
        {
            _students.Update(student);
        }

        public void Delete(Student student)
        {
            _students.Remove(student);
        }

        public void Save()
        {
            _context.Save();
        }

        
    }
}
