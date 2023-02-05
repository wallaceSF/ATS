using FluentValidation.Results;

namespace ATSControlSystem.Application.Models.Request;

public abstract class BaseModelDtoRequest
{
    public abstract bool Validate(out List<ValidationFailure> errors);
}