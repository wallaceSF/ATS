using ATSControlSystem.Application.Models.Validator.Request;
using FluentValidation.Results;

namespace ATSControlSystem.Application.Models.Request;

public class CreateCandidateRequestDto : BaseModelDtoRequest
{
    public string Occupation { get; set; }

    public DateTime BirthDate { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }
    
    public string Document { get; set; }

    public string Resume { get; set; }
    
    public override bool Validate(out List<ValidationFailure> errors)
    {
        var x = new CreateCandidateRequestDtoValidator()
            .Validate(this);

        errors = x.Errors;
        return x.IsValid;
    }
}