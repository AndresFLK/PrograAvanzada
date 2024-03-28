using Domain.Students;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Students
{
    public interface IStudentClient
    {
        Task<List<StudentDTO>> List();

        Task<Result> Create(CreateStudent createStudent);

        Task<Result> Update(UpdateStudent updateStudent);

        Task<Result<Student>> Get(string batch);

        
    }
}
