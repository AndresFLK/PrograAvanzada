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
        Result<IList<Student>> List();

        Result<Student> Get(string batch);

        Result<Student> Get(int id);

        Result Create(CreateStudent createStudent);

        Result Update(UpdateStudent updateStudent);

        Result Delete(int id);
    }
}
