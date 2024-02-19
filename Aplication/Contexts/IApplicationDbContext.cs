using Domain.Students;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Contexts
{
    public interface IApplicationDbContext
    {
        DbSet<Student> Students { get; set; }

        void Save();
    }
}
