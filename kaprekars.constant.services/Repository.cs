using FluentValidation;
using Microsoft.Extensions.Logging;
using kaprekars.constant.data;

namespace kaprekars.constant.services;

public class Repository : IRepository
{
    private readonly ILogger<Repository> _logger;
    private readonly IValidator<Request> _validator;

    public Repository(
        ILogger<Repository> logger,
        IValidator<Request> validator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
    }

    public IEnumerable<Routine> GetRoutines(Request request)
    {
        try
        {
            _validator.ValidateAndThrow(request);

            var iterations = 0;
            var routines = new List<Routine>();
            var num = int.Parse(request.Number);
            var routine = GetRoutine(num);

            routines.Add(routine);

            if (routine.Result == Constants.KaprekarsConstant)
                return routines;

            while (routine.Result != Constants.KaprekarsConstant)
            {
                routine = GetRoutine(routine.Result);
                routines.Add(routine);
                iterations++;

                if (iterations >= 7)
                {
                    throw new ApplicationException("Could not find Kaprekar's constant from the number provided");
                }
            }

            return routines;
        }
        catch (ValidationException ex)
        {
            _logger.LogError(ex,
                "Error while validating. {ValidationExceptionPropertyName} - {ValidationExceptionErrorMessage}",
                ex.Errors.First().PropertyName,
                ex.Errors.First().ErrorMessage);

            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,
                "Error while getting routines. Message {ExceptionMessage}",
                ex.Message);

            throw;
        }
    }

    public Routine GetRoutine(int number)
    {
        var num = number;
        var asc = Math.Abs(num.ToAscendingOrder());
        var desc = Math.Abs(num.ToDescendingOrder());
        var res = desc > asc
            ? desc - asc
            : asc - desc;
        var subtraction = desc > asc
            ? $"{desc} - {asc}"
            : $"{asc} - {desc}";

        return new Routine
        {
            Number = num,
            Ascending = asc,
            Descending = desc,
            Result = res,
            Subtraction = $"{subtraction} = {res}"
        };
    }
}
