using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Logging;
using BenchmarkDotNet.Attributes;
using NSubstitute;
using kaprekars.constant.data;

namespace kaprekars.constant.services
{
    [ExcludeFromCodeCoverage]
    public class BenchmarkRepository
    {
        private readonly IRepository _repo;

        public BenchmarkRepository()
        {
            _repo = new Repository(
                Substitute.For<ILogger<Repository>>(),
                new RequestValidator());
        }

        [Benchmark]
        public void BenchmarkGetRoutines()
        {
            for (int i = 0; i < 1000; i++)
            {
                _repo.GetRoutines(new data.Request { Number = "8523" });
            }
        }
    }
}
