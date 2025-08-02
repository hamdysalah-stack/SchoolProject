using FluentValidation;
using SchoolProject.Core.Features.User.Commands.Models;

namespace SchoolProject.Core.Features.User.Commands.Validation
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {

        #region Fileds

        #endregion


        #region  Constructor
        public AddUserValidator()
        {
            ApplyValidationRule();
            ApplyCustomeValidationRule();


        }
        #endregion




        #region  Handle Functions

        public void ApplyValidationRule()
        {
            RuleFor(x => x.FullName)
                 .NotEmpty().WithMessage("name must not Empty")
                 .NotNull().WithMessage("name must not Null");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("{PropertyName} must not Empty")
                .NotNull().WithMessage("{PropertyValue} must not Null");

            RuleFor(x => x.Email)
           .NotEmpty().WithMessage("{PropertyName} must not Empty")
           .NotNull().WithMessage("{PropertyValue} must not Null");

            RuleFor(x => x.Password)
          .NotEmpty().WithMessage("{PropertyName} must not Empty")
          .NotNull().WithMessage("{PropertyValue} must not Null");


            RuleFor(x => x.ConfirmPassword)
          .NotEmpty().WithMessage("{PropertyName} must not Empty")
          .NotNull().WithMessage("{PropertyValue} must not Null")
          .Matches(x => x.Password).WithMessage("must matches password and Confirm Password");

        }

        public void ApplyCustomeValidationRule()
        {
            //RuleFor(x => x.Name)
            //    .MustAsync(async (Key, CancellationToken) => !await _studentServices.IsNameExist(Key))
            //    .WithMessage("Name is Exist");
        }
        #endregion

    }
}
