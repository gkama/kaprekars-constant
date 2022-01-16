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

    
}
