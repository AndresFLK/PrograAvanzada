using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Students
{
    public static class StudentErrors
    {
        public static Error NotFound(string batch) => new Error("NOT_FOUND", $"The student with Batch {batch} was not found");

        public static Error NotFound() => new Error("NOT_FOUND", $"The student was not found");

        public static Error NotCreated() => new Error("Students.NOT_CREATED", "The Student was not created.");
        public static Error NotUpdated() => new Error("Students.NOT_UPDATED", "The Student was not updated.");



    }
}
