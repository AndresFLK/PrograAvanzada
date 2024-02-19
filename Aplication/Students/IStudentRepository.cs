using Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Students
{
    public interface IStudentRepository
    {
        List<Student> GetAll();

        Student Get(Expression<Func<Student, bool>> predicate);

        void Insert(Student student);
        void Update(Student student);

        void Delete(Student student);

        void Save();
    }
}
