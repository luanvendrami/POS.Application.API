using Domain.Dto;
using Domain.Enum;
using FluentValidation.TestHelper;
using POS.Application.API.FluentValidation;
using Xunit;

public class DrinkOrderDtoValidatorTests
{
    private readonly DrinkOrderDtoValidator _validator;

    public DrinkOrderDtoValidatorTests()
    {
        _validator = new DrinkOrderDtoValidator();
    }

    [Fact]
    public void Should_Have_Error_When_Id_Is_Empty()
    {
        var invalidId = 0;
        var result = _validator.TestValidate(new DrinkOrderDto { IdOrder = invalidId });

        result.ShouldHaveValidationErrorFor(dto => dto.IdOrder);
    }

    [Fact]
    public void Should_Have_Error_When_SpecialInstructions_Exceed_Max_Length()
    {
        var invalidInstructions = new string('A', 256); // Assuming the max length is 255
        var result = _validator.TestValidate(new DrinkOrderDto { SpecialInstructions = invalidInstructions });

        result.ShouldHaveValidationErrorFor(dto => dto.SpecialInstructions);
    }

    [Fact]
    public void Should_Have_Error_When_Type()
    {
        var validDto = new DrinkOrderDto
        {
            IdOrder = 1,
            SpecialInstructions = "Some special instructions",
            Type = (DrinkType)7,
            IcePreference = IceLevel.Regular,
            Quantity = 2
        };
        var result = _validator.TestValidate(validDto);

        result.ShouldHaveValidationErrorFor(dto => dto.Type);
    }

    [Fact]
    public void Should_Have_Error_When_IcePreference()
    {
        var validDto = new DrinkOrderDto
        {
            IdOrder = 1,
            SpecialInstructions = "Some special instructions",
            Type = DrinkType.Coffee,
            IcePreference = (IceLevel)7,
            Quantity = 2
        };
        var result = _validator.TestValidate(validDto);

        result.ShouldHaveValidationErrorFor(dto => dto.IcePreference);
    }

    [Fact]
    public void Should_Have_Error_When_Quantity()
    {
        var validDto = new DrinkOrderDto
        {
            IdOrder = 1,
            SpecialInstructions = "Some special instructions",
            Type = DrinkType.Coffee,
            IcePreference = IceLevel.None,
            Quantity = 0
        };
        var result = _validator.TestValidate(validDto);

        result.ShouldHaveValidationErrorFor(dto => dto.Quantity);
    }

    [Fact]
    public void Should_Not_Have_Error_When_All_Properties_Are_Valid()
    {
        var validDto = new DrinkOrderDto
        {
            IdOrder = 1,
            SpecialInstructions = "Some special instructions",
            Type = DrinkType.Coffee,
            IcePreference = IceLevel.Regular,
            Quantity = 2
        };
        var result = _validator.TestValidate(validDto);

        result.ShouldNotHaveAnyValidationErrors();
    }
}
