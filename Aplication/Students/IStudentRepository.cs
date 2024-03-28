using Aplication.Repositories;
using Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Students
{
    public interface IStudentRepository : IRepositoryBase<Student>
    {
    }
}
