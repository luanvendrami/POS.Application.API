using Domain.Dto;
using Domain.Enum;
using FluentValidation.TestHelper;
using POS.Application.API.FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class GrillOrderDtoValidatorTest
    {
        private readonly GrillOrderDtoValidator _validator;


        public GrillOrderDtoValidatorTest()
        {
            _validator = new GrillOrderDtoValidator();
        }

        [Fact]
        public void Should_Have_Error_When_Id_Is_Empty()
        {
            var invalidId = 0;
            var result = _validator.TestValidate(new GrillOrderDto { IdOrder = invalidId });

            result.ShouldHaveValidationErrorFor(dto => dto.IdOrder);
        }

        [Fact]
        public void Should_Have_Error_When_SpecialInstructions_Exceed_Max_Length()
        {
            var invalidInstructions = new string('A', 256);    
            var result = _validator.TestValidate(new GrillOrderDto { SpecialInstructions = invalidInstructions });

            result.ShouldHaveValidationErrorFor(dto => dto.SpecialInstructions);
        }

        [Fact]
        public void Should_Have_Error_When_MeatType()
        {
            var invalidMeatType = new GrillOrderDto
            {
                IdOrder = 1,
                SpecialInstructions = "Some special instructions",
                Meat = (MeatType)100,
                CookingPreference = CookingLevel.Rare,
                Quantity = 2,
            }; 
            var result = _validator.TestValidate(invalidMeatType);

            result.ShouldHaveValidationErrorFor(dto => dto.Meat);
        }

        [Fact]
        public void Should_Have_Error_When_CookingPreference()
        {
            var invalidCookingPreference = new GrillOrderDto
            {
                IdOrder = 1,
                SpecialInstructions = "Some special instructions",
                Meat = MeatType.Beef,
                CookingPreference = (CookingLevel)200,
                Quantity = 1,
            }; 
            var result = _validator.TestValidate(invalidCookingPreference);

            result.ShouldHaveValidationErrorFor(dto => dto.CookingPreference);
        }

        [Fact]
        public void Should_Have_Error_When_Quantity()
        {
            var invalidQuantity = new GrillOrderDto
            {
                IdOrder = 1,
                SpecialInstructions = "Some special instructions",
                Meat = MeatType.Beef,
                CookingPreference = CookingLevel.Rare,
                Quantity = 0,
            }; 
            var result = _validator.TestValidate(invalidQuantity);

            result.ShouldHaveValidationErrorFor(dto => dto.Quantity);
        }

        [Fact]
        public void Should_Not_Have_Error_When_All_Properties_Are_Valid()
        {
            var validDto = new GrillOrderDto
            {
                IdOrder = 1,
                SpecialInstructions = "Some special instructions",
                Meat = MeatType.Pork,
                CookingPreference = CookingLevel.MediumRare,
                Quantity = 3,
            };
            var result = _validator.TestValidate(validDto);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
