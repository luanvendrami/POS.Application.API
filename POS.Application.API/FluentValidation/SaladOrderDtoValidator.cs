using Domain.Dto.Request;
using FluentValidation;

namespace POS.Application.API.FluentValidation
{
    public class SaladOrderDtoValidator : AbstractValidator<SaladOrderDto>
    {
        public SaladOrderDtoValidator()
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
                .WithMessage("One salad type is required.");

            RuleFor(dto => dto.Dressing)
                .IsInEnum()
                .WithMessage("One dressing is required.");

            RuleFor(dto => dto.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than zero.");
        }
    }
}
