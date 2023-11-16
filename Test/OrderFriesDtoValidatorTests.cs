using Domain.Dto;
using Domain.Enum;
using FluentValidation.TestHelper;
using POS.Application.API.FluentValidation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class OrderFriesDtoValidatorTests
    {
        private readonly OrderFriesDtoValidator _validator;

        public OrderFriesDtoValidatorTests()
        {
            _validator = new OrderFriesDtoValidator();
        }

        [Fact]
        public void Should_Have_Error_When_Id_Is_Empty()
        {
            var invalidId = 0;
            var result = _validator.TestValidate(new OrderFriesDto { IdOrder = invalidId });

            result.ShouldHaveValidationErrorFor(dto => dto.IdOrder);
        }

        [Fact]
        public void Should_Have_Error_When_SpecialInstructions_Exceed_Max_Length()
        {
            var invalidInstructions = new string('A', 256); // Assuming the max length is 255
            var result = _validator.TestValidate(new OrderFriesDto { SpecialInstructions = invalidInstructions });

            result.ShouldHaveValidationErrorFor(dto => dto.SpecialInstructions);
        }

        [Fact]
        public void Should_Have_Error_When_Size()
        {
            var invalidMeatType = new OrderFriesDto
            {
                IdOrder = 1,
                SpecialInstructions = "Some special instructions",
                Size = (FriesSize)8,
                Sauce = SauceType.Mayonnaise,
                Quantity = 1,
            };
            var result = _validator.TestValidate(invalidMeatType);

            result.ShouldHaveValidationErrorFor(dto => dto.Size);
        }

        [Fact]
        public void Should_Have_Error_When_Sauces()
        {
            var invalidMeatType = new OrderFriesDto
            {
                IdOrder = 1,
                SpecialInstructions = "Some special instructions",
                Size = FriesSize.Medium,
                Sauce = (SauceType)7,
                Quantity = 1,
            };
            var result = _validator.TestValidate(invalidMeatType);

            result.ShouldHaveValidationErrorFor(dto => dto.Sauce);
        }

        [Fact]
        public void Should_Have_Error_When_Quantity()
        {
            var invalidMeatType = new OrderFriesDto
            {
                IdOrder = 1,
                SpecialInstructions = "Some special instructions",
                Size = FriesSize.Medium,
                Sauce = SauceType.Mayonnaise,
                Quantity = 0,
            };
            var result = _validator.TestValidate(invalidMeatType);

            result.ShouldHaveValidationErrorFor(dto => dto.Quantity);
        }

        [Fact]
        public void Should_Not_Have_Error_When_All_Properties_Are_Valid()
        {
            var validDto = new OrderFriesDto
            {
                IdOrder = 1,
                SpecialInstructions = "Some special instructions",
                Size = FriesSize.Medium,
                Sauce = SauceType.Mayonnaise,
                Quantity = 1,
            };
            var result = _validator.TestValidate(validDto);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
