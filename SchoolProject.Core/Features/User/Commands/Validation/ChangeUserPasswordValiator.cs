using FluentValidation;
using SchoolProject.Core.Features.User.Commands.Models;

namespace SchoolProject.Core.Features.User.Commands.Validation
{
    public class ChangeUserPasswordValiator : AbstractValidator<ChangeUserPasswordCommand>
    {

        #region Fileds

        #endregion


        #region  Constructor
        public ChangeUserPasswordValiator()
        {
            ApplyValidationRule();
            ApplyCustomeValidationRule();


        }
        #endregion




        #region  Handle Functions

        public void ApplyValidationRule()
        {
            RuleFor(x => x.Id)
                 .NotEmpty().WithMessage("{PropertyName}  must not Empty")
                 .NotNull().WithMessage("{PropertyName}  must not Null");

            RuleFor(x => x.CurrentPassword)
                .NotEmpty().WithMessage("{PropertyName} must not Empty")
                .NotNull().WithMessage("{PropertyValue} must not Null");

            RuleFor(x => x.NewPassword)
           .NotEmpty().WithMessage("{PropertyName} must not Empty")
           .NotNull().WithMessage("{PropertyValue} must not Null");




            RuleFor(x => x.ConfirmPassword)
          .NotEmpty().WithMessage("{PropertyName} must not Empty")
          .NotNull().WithMessage("{PropertyValue} must not Null")
          .Matches(x => x.NewPassword).WithMessage("must matches password and Confirm Password");

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
