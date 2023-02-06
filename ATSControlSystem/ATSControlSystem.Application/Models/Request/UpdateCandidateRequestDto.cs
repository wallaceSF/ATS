using System.Collections.Generic;
using ATSControlSystem.Application.Models.Validator.Request;
using ATSControlSystem.Domain.Contract.Application;
using FluentValidation.Results;

namespace ATSControlSystem.Application.Models.Request;

public class UpdateCandidateRequestDto : BaseModelDtoRequest, IUpdateCandidateProfileDto
{
    public string Id { get; set; }
    
    public string Occupation { get; set; }

    public string Email { get; set; }

    public string Document { get; set; }

    public string Resume { get; set; }

    public override bool Validate(out List<ValidationFailure> errors)
    {
        var x = new UpdateCandidateRequestDtoValidator()
            .Validate(this);

        errors = x.Errors;
        return x.IsValid;
    }
}