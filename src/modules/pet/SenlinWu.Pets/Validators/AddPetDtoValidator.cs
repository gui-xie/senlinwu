using FluentValidation;
using SenlinWu.Pets.Application;

namespace SenlinWu.Pets.Validators;

public class AddPetDtoValidator: AbstractValidator<AddPetDto>
{
    public AddPetDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(4);
    }
}