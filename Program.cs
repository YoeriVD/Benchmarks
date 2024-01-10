// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using Benchmarks.OverEngineering;
using Benchmarks.StructsAsInterface;

// BenchmarkRunner.Run<BenchmarkStructs>();

BenchmarkRunner.Run<SwitchVsCalculate>();