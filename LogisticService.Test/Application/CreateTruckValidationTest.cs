using FluentValidation.TestHelper;
using LogisticService.Application.Commands.Trucks.Create;

namespace LogisticService.Test.Application
{
	public class CreateTruckValidationTest
	{
        private CreateTruckCommandValidator _createTruckValidator;
        [SetUp]
        public void Setup()
        {
            _createTruckValidator = new CreateTruckCommandValidator();
        }

        [Test]
        public void Should_Have_Error_When_LicensePlate_Is_Empty()   
        {
            var model = new CreateTruckCommand(null, null, null, 0);

            var result = _createTruckValidator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(truck => truck.LicensePlate);
        }

        [Test]
        public void Should_Have_Error_When_LicensePlate_Length_Is_Greater_To_10()   
        {
            var model = new CreateTruckCommand("12345678901", null, null, 0);

            var result = _createTruckValidator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(truck => truck.LicensePlate);
        }

        [Test]
        public void Should_Not_Have_Error_When_LicensePlate_Length_Is_Less_To_10()   
        {
            var model = new CreateTruckCommand("123456789", null, null, 0);

            var result = _createTruckValidator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(truck => truck.LicensePlate);
        }

        [Test]
        public void Should_Have_Error_When_Color_Is_Empty()   
        {
            var model = new CreateTruckCommand(null, null, null, 0);

            var result = _createTruckValidator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(truck => truck.Color);
        }

        [Test]
        public void Should_Have_Error_When_Color_Length_Is_Greater_Than_50()   
        {
            var model = new CreateTruckCommand(null, "123456789012345678901234567890123456789012345678901", null, 0);

            var result = _createTruckValidator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(truck => truck.Color);
        }

        [Test]
        public void Should_Not_Have_Error_When_Color_Length_Is_Less_Than_50()   
        {
            var model = new CreateTruckCommand(null, "1234567890123456789012345678901234567890123456789", null, 0);

            var result = _createTruckValidator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(truck => truck.Color);
        }

        [Test]
        public void Should_Have_Error_When_Brand_Is_Empty()   
        {
            var model = new CreateTruckCommand(null, null, null, 0);

            var result = _createTruckValidator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(truck => truck.Brand);
        }

        [Test]
        public void Should_Have_Error_When_Brand_Length_Is_Greater_Than_50()   
        {
            var model = new CreateTruckCommand(null, null, "123456789012345678901234567890123456789012345678901", 0);

            var result = _createTruckValidator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(truck => truck.Brand);
        }

        [Test]
        public void Should_Not_Have_Error_When_Brand_Length_Is_Less_Than_50()   
        {
            var model = new CreateTruckCommand(null, null, "1234567890123456789012345678901234567890123456789", 0);

            var result = _createTruckValidator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(truck => truck.Brand);
        }

        [Test]
        public void Should_Have_Error_When_YearModel_Is_Less_Than_1990()   
        {
            var model = new CreateTruckCommand(null, null, null, 1989);

            var result = _createTruckValidator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(truck => truck.YearModel);
        }

        [Test]
        public void Should_Not_Have_Error_When_YearModel_Is_Equal_Than_1990()   
        {
            var model = new CreateTruckCommand(null, null, null, 1990);

            var result = _createTruckValidator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(truck => truck.YearModel);
        }

        [Test]
        public void Should_Not_Have_Error_When_YearModel_Is_Greater_Than_1990()   
        {
            var model = new CreateTruckCommand(null, null, null, 1991);

            var result = _createTruckValidator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(truck => truck.YearModel);
        }
    }
}

