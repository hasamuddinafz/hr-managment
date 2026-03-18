using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagment.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; }

        public ValidationException(IEnumerable<ValidationFailure> failures) : base("Validation failed")
        {
            Errors = failures.Select(f => f.ErrorMessage).ToList();
        }
    }
}
