using BilgeKitap.Core.Extensions;
using FluentValidation.Results;
using System.Collections.Generic;

public class ValidationErrorDetails : ErrorDetails
{
    public IEnumerable<ValidationFailure> Errors { get; set; }
}

