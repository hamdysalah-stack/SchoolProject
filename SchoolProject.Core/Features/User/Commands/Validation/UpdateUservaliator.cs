using FluentValidation;
using SchoolProject.Core.Features.User.Commands.Models;

namespace SchoolProject.Core.Features.User.Commands.Validation
{
    public class UpdateUservaliator : AbstractValidator<UpdateUserCommand>
    {

        #region Fileds

        #endregion


        #region  Constructor
        public UpdateUservaliator()
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
