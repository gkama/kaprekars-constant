using Microsoft.Extensions.Logging;

namespace kaprekars.constant.services;

public class Repository : IRepository
{
    private readonly ILogger<Repository> _logger;

    public Repository(
        ILogger<Repository> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
}
