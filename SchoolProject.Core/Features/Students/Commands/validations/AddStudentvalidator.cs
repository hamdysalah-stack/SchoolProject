using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.models;
using SchoolProject.Services.Interface;

namespace SchoolProject.Core.Features.Students.Commands.validations
{
    public class AddStudentvalidator : AbstractValidator<AddStudentCommand>
    {

        #region filelds
        private readonly IStudentServices _studentServices;

        #endregion

        #region construtor
        public AddStudentvalidator(IStudentServices studentServices)
        {
            ApplyValidationRule();
            ApplyCustomeValidationRule();
            _studentServices = studentServices;

        }
        #endregion

        #region handle function (Action)

        public void ApplyValidationRule()
        {
            RuleFor(x => x.Name)
                 .NotEmpty().WithMessage("name must not Empty")
                 .NotNull().WithMessage("name must not Null")
                 .MaximumLength(15).WithMessage("Max lenngth is 3");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("{PropertyName} must not Empty")
                .NotNull().WithMessage("{PropertyValue} must not Null")
                .MaximumLength(15).WithMessage("Max lenngth is 3");

        }

        public void ApplyCustomeValidationRule()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (Key, CancellationToken) => !await _studentServices.IsNameExist(Key))
                .WithMessage("Name is Exist");
        }

        #endregion
    }
}
