using ATSControlSystem.Application.Models.Request;
using FluentValidation;

namespace ATSControlSystem.Application.Models.Validator.Request;

public class UpdateCandidateRequestDtoValidator : AbstractValidator<UpdateCandidateRequestDto>
{
    public UpdateCandidateRequestDtoValidator()
    {
        RuleFor(candidateRequestDto => candidateRequestDto.Document)
            .MaximumLength(10).WithMessage("Document not exceed 10 characters.")
            .NotEmpty().WithMessage("Document is required");

        RuleFor(candidateRequestDto => candidateRequestDto.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("A valid email is required");
    }
}