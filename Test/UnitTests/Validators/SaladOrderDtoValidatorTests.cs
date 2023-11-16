using Domain.Dto.Request;
using Domain.Enum;
using FluentValidation.TestHelper;
using POS.Application.API.FluentValidation;
using Xunit;

namespace Test
{
    public class SaladOrderDtoValidatorTests
    {
        private readonly SaladOrderDtoValidator _validator;


        public SaladOrderDtoValidatorTests()
        {
            _validator = new SaladOrderDtoValidator();
        }

        [Fact]
        public void Should_Have_Error_When_Id_Is_Empty()
        {
            var invalidId = 0;
            var result = _validator.TestValidate(new SaladOrderDto { IdOrder = invalidId });

            result.ShouldHaveValidationErrorFor(dto => dto.IdOrder);
        }

        [Fact]
        public void Should_Have_Error_When_SpecialInstructions_Exceed_Max_Length()
        {
            var invalidInstructions = new string('A', 256);
            var result = _validator.TestValidate(new SaladOrderDto { SpecialInstructions = invalidInstructions });

            result.ShouldHaveValidationErrorFor(dto => dto.SpecialInstructions);
        }

        [Fact]
        public void Should_Have_Error_When_SaladType()
        {
            var invalidMeatType = new SaladOrderDto
            {
                IdOrder = 1,
                SpecialInstructions = "Some special instructions",
                Type = (SaladType)8,
                Dressing = DressingType.Ranch,
                Quantity = 2,
            };
            var result = _validator.TestValidate(invalidMeatType);

            result.ShouldHaveValidationErrorFor(dto => dto.Type);
        }

        [Fact]
        public void Should_Have_Error_When_Dressings()
        {
            var invalidMeatType = new SaladOrderDto
            {
                IdOrder = 1,
                SpecialInstructions = "Some special instructions",
                Type = SaladType.Caprese,
                Dressing = (DressingType)8,
                Quantity = 1,
            };
            var result = _validator.TestValidate(invalidMeatType);

            result.ShouldHaveValidationErrorFor(dto => dto.Dressing);
        }

        [Fact]
        public void Should_Have_Error_When_Quantity()
        {
            var invalidMeatType = new SaladOrderDto
            {
                IdOrder = 1,
                SpecialInstructions = "Some special instructions",
                Type = SaladType.Caprese,
                Dressing = DressingType.Ranch,
                Quantity = 0,
            };
            var result = _validator.TestValidate(invalidMeatType);

            result.ShouldHaveValidationErrorFor(dto => dto.Quantity);
        }
    }
}
