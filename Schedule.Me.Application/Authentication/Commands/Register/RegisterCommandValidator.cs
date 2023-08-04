using FluentValidation;

namespace Schedule.Me.Application.Authentication.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.Password)
                .NotEmpty().WithErrorCode("PasswordEmpty")
                .MinimumLength(8).WithErrorCode("PasswordTooShort")
                .MaximumLength(16).WithErrorCode("PasswordTooLong");
            RuleFor(x => x.FirstName)
                .NotEmpty();
            RuleFor(x => x.LastName)
                .NotEmpty();
        }
    }
}