using Domain.Students;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Students
{
    public interface IStudentService
    {
        Result<IList<Student>> List(bool includeCourses = false);

        Result<Student> Get(string batch, bool includeCourses = false);

        Result<Student> Get(int id, bool includeCourses = false);

        Result Create(CreateStudent createStudent);

        Result Update(UpdateStudent updateStudent);

        Result Delete(int id);
    }
}
