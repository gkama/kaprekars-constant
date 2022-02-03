using BenchmarkDotNet;
using BenchmarkDotNet.Running;
using kaprekars.constant.benchmarks;

Console.WriteLine("Starting benchmarks");

 var summary = BenchmarkRunner.Run<BenchmarkRepository>();
Console.WriteLine(summary);

Console.WriteLine("Finished benchmarks");