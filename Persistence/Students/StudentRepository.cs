using Aplication.Contexts;
using Aplication.Students;
using Domain.Students;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence.Students
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {

        public StudentRepository(ApplicationDbContext context) : base(context)
        {
            
        }


       
    }
}
