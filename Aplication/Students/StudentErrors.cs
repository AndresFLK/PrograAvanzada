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
    }
}
