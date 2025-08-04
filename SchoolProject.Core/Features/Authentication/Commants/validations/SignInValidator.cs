using FluentValidation;
using SchoolProject.Core.Features.Authentication.Commants.Models;

namespace SchoolProject.Core.Features.Authentication.Commants.validations
{
    internal class SignInValidator : AbstractValidator<SignInCommand>
    {

        #region Fileds

        #endregion


        #region  Constructor
        public SignInValidator()
        {
            ApplyValidationRule();
            ApplyCustomeValidationRule();


        }
        #endregion




        #region  Handle Functions

        public void ApplyValidationRule()
        {
            RuleFor(x => x.UserName)
                 .NotEmpty().WithMessage("{PropertyName}  must not Empty")
                 .NotNull().WithMessage("{PropertyName}  must not Null");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("{PropertyName} must not Empty")
                .NotNull().WithMessage("{PropertyValue} must not Null");
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
