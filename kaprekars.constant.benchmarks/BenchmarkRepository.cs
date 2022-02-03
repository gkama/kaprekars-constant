using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Logging;
using BenchmarkDotNet.Attributes;
using NSubstitute;
using kaprekars.constant.data;
using kaprekars.constant.services;

namespace kaprekars.constant.benchmarks
{
    [ExcludeFromCodeCoverage]
    public class BenchmarkRepository
    {
        private readonly IRepository _repo;

        [Params(10, 1000)]
        public int Iterations { get; set; }

        public BenchmarkRepository()
        {
            _repo = new Repository(
                Substitute.For<ILogger<Repository>>(),
                new RequestValidator());
        }

        [Benchmark]
        public void BenchmarkGetRoutines()
        {
            for (int i = 0; i < Iterations; i++)
            {
                _repo.GetRoutines(new data.Request { Number = "8523" });
            }
        }
    }
}
