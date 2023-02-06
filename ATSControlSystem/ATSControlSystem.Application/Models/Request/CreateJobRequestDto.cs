using System.Collections.Generic;
using ATSControlSystem.Application.Models.Validator.Request;
using FluentValidation.Results;

namespace ATSControlSystem.Application.Models.Request;

public class CreateJobRequestDto : BaseModelDtoRequest
{
    public string Title { get; set; }

    public string Description { get; set; }

    public string Seniority { get; set; }

    public decimal Salary { get; set; }

    public override bool Validate(out List<ValidationFailure> errors)
    {
        var x = new CreateJobRequestDtoValidator()
            .Validate(this);

        errors = x.Errors;
        return x.IsValid;
    }
}

