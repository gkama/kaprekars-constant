using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Logging;
using BenchmarkDotNet.Attributes;
using NSubstitute;
using FluentValidation;
using kaprekars.constant.data;
using kaprekars.constant.services;

namespace kaprekars.constant.benchmarks
{
    [ExcludeFromCodeCoverage]
    public class BenchmarkRepository
    {
        [Params(100)]
        public int Iterations { get; set; }

        public int _min { get; } = 1000;
        public int _max { get; } = 9999;

        private readonly IRepository _repo;
        private readonly IValidator<Request> _validator;

        public BenchmarkRepository()
        {
            _validator = new RequestValidator();
            _repo = new Repository(Substitute.For<ILogger<Repository>>(), _validator);
        }

        private int RandomFourDigitNumber()
        {
            var random = new Random();
            var num = random.Next(_min, _max);

            return _validator.Validate(new Request { Number = num.ToString() }).IsValid
                ? num
                : RandomFourDigitNumber();
        }

        [Benchmark]
        public void BenchmarkGetRoutines()
        {
            for (int i = 0; i < Iterations; i++)
            {
                var num = RandomFourDigitNumber().ToString();
                try
                {
                    _repo.GetRoutines(new Request { Number = num });
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message}. Number {num}");
                }
            }
        }
    }
}
