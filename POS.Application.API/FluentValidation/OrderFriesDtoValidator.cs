using Domain.Dto.Request;
using FluentValidation;

namespace POS.Application.API.FluentValidation
{
    public class OrderFriesDtoValidator : AbstractValidator<OrderFriesDto>
    {
        public OrderFriesDtoValidator()
        {
            RuleFor(dto => dto.IdOrder)
                .NotEmpty()
                .NotNull()
                .WithMessage("Id is required.");

            RuleFor(dto => dto.SpecialInstructions)
                .MaximumLength(255)
                .WithMessage("Instruction text is too large.");

            RuleFor(dto => dto.Size)
                .IsInEnum()
                .WithMessage("One size is required.");

            RuleFor(dto => dto.Sauce)
                .IsInEnum()
                .WithMessage("One Sauce is required.");

            RuleFor(dto => dto.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than zero.");
        }
    }
}
