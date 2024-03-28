using Domain.Students;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Students
{
    public class CreateStudentValidator : AbstractValidator<CreateStudent>
    { 
        public CreateStudentValidator()
        {
            RuleFor(o => o.Batch).Length(5, 10);      
            RuleFor(o => o.FirstName).Length(2, 40);      
            RuleFor(o => o.LastName).Length(2, 40);      
            RuleFor(o => o.BirthDate).InclusiveBetween(new DateTime(1900, 01, 01), new DateTime(2024, 12, 12));
            RuleFor(o => o.Email).Length(5, 150).EmailAddress();
            RuleFor(o => o.MobileNumber).Length(8, 15);
        }
    }
}
