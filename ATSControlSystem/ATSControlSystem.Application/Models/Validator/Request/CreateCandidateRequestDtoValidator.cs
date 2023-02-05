using ATSControlSystem.Application.Models.Request;
using FluentValidation;

namespace ATSControlSystem.Application.Models.Validator.Request;

public class CreateCandidateRequestDtoValidator : AbstractValidator<CreateCandidateRequestDto>
{
    public CreateCandidateRequestDtoValidator()
    {
        RuleFor(candidateRequestDto => candidateRequestDto.FirstName)
            .MaximumLength(50).WithMessage("Firstname not exceed 50 characters.")
            .NotEmpty().WithMessage("Firstname is required");

        RuleFor(candidateRequestDto => candidateRequestDto.LastName)
            .MaximumLength(50).WithMessage("LastName not exceed 50 characters.")
            .NotEmpty().WithMessage("LastName is required");

        RuleFor(candidateRequestDto => candidateRequestDto.Document)
            .MaximumLength(10).WithMessage("Document not exceed 10 characters.")
            .NotEmpty().WithMessage("Document is required");

        RuleFor(candidateRequestDto => candidateRequestDto.BirthDate)
            .Must(date => !date.Equals(default)).WithMessage("BirthDate is required");

        RuleFor(candidateRequestDto => candidateRequestDto.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("A valid email is required");
    }
}