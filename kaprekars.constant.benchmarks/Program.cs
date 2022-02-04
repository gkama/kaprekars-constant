using BenchmarkDotNet.Running;
using kaprekars.constant.benchmarks;

var summary = BenchmarkRunner.Run<BenchmarkRepository>();

Console.WriteLine(summary);