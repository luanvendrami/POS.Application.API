using Domain.Dto.Request;
using FluentValidation;

namespace POS.Application.API.FluentValidation
{
    public class GrillOrderDtoValidator : AbstractValidator<GrillOrderDto>
    {
        public GrillOrderDtoValidator()
        {
            RuleFor(dto => dto.IdOrder)
                .NotEmpty()
                .NotNull()
                .WithMessage("Id is required.");

            RuleFor(dto => dto.SpecialInstructions)
                .MaximumLength(255)
                .WithMessage("Instruction text is too large.");

            RuleFor(dto => dto.Meat)
                .IsInEnum()
                .WithMessage("One type to meat is required.");

            RuleFor(dto => dto.CookingPreference)
                .IsInEnum()
                .WithMessage("Cooking preference is required.");

            RuleFor(dto => dto.SideDishes)
                .NotNull()
                .WithMessage("Fill in if the order has accompaniments.");

            RuleFor(dto => dto.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than zero.");
        }
    }
}
