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
            .Must(x => int.TryParse(x, out _))
            .WithMessage("Must be a four-digit number")
            .Must(x => x.HasAtleastTwoUniqueDigits())
            .WithMessage("Must have at least two unique digits");
    }
}