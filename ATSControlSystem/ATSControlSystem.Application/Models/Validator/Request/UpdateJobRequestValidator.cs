using ATSControlSystem.Application.Models.Request;
using FluentValidation;

namespace ATSControlSystem.Application.Models.Validator.Request;

public class UpdateJobRequestValidator : AbstractValidator<UpdateJobRequestDto>
{
    public UpdateJobRequestValidator()
    {
        RuleFor(createJobRequestDto => createJobRequestDto.Id)
            .NotEmpty().WithMessage("Id is required");
        
        RuleFor(createJobRequestDto => createJobRequestDto.Title)
            .MaximumLength(50).WithMessage("Firstname not exceed 50 characters.")
            .NotEmpty().WithMessage("Title is required");

        RuleFor(createJobRequestDto => createJobRequestDto.Description)
            .MaximumLength(300).WithMessage("Description not exceed 300 characters.")
            .NotEmpty().WithMessage("Description is required");

        RuleFor(createJobRequestDto => createJobRequestDto.Seniority)
            .NotEmpty().WithMessage("Seniority is required");
    }
}