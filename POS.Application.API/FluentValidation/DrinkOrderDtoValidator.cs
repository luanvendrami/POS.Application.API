using Domain.Dto.Request;
using FluentValidation;

namespace POS.Application.API.FluentValidation
{
    public class DrinkOrderDtoValidator : AbstractValidator<DrinkOrderDto>
    {
        public DrinkOrderDtoValidator()
        {
            RuleFor(dto => dto.IdOrder)
                .NotEmpty()
                .NotNull()
                .WithMessage("Id is required.");

            RuleFor(dto => dto.SpecialInstructions)
                .MaximumLength(255)
                .WithMessage("Instruction text is too large.");

            RuleFor(dto => dto.Type)
                .IsInEnum()
                .WithMessage("One type to drink is required.");

            RuleFor(dto => dto.IcePreference)
                .IsInEnum()
                .WithMessage("Ice level is required.");

            RuleFor(dto => dto.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than zero.");
        }
    }
}
