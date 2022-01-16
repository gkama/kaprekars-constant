using FluentValidation;

namespace kaprekars.constant.data;

public class RequestValidator : AbstractValidator<Request>
{
    public RequestValidator()
    {
        RuleFor(x => x.Number)
            .NotEmpty()
            .Length(4)
            .Must(x =>
            {
                return int.TryParse(x, out _);
            })
            .WithMessage("Number must be a valid four-digit number")
            .Must(x =>
            {
                return int.Parse(x).HasAtleastTwoUniqueDigits();
            })
            .WithMessage("Number must have at least two unique digits");
    }
}