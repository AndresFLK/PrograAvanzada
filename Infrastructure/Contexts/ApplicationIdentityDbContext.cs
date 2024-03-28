using Aplication.Contexts;
using Domain.Courses;
using Domain.Students;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public class ApplicationIdentityDbContext : IdentityDbContext, IApplicationIdentityDbContext
    {

        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) : base(options)
        {
            
        }

    }
}
