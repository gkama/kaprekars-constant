using FluentValidation;
namespace kaprekars.constant.data;

public class RequestValidator : AbstractValidator<Request>
{
    public RequestValidator()
    {
        ValidatorOptions.Global.CascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Number)
            .NotEmpty()
            .Length(4)
            .Must(x => !x.StartsWith("0"))
            .WithMessage("Must not start with 0")
            .Must(x => int.TryParse(x, out _))
            .WithMessage("Must be a four-digit number")
            .Must(x => int.Parse(x).HasAtleastTwoUniqueDigits())
            .WithMessage("Must have at least two unique digits");
    }
}