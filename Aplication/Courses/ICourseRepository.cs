using Aplication.Repositories;
using Domain.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Courses
{
    public interface ICourseRepository : IRepositoryBase<Course>
    {
    }
}
