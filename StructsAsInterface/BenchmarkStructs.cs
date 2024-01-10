using BenchmarkDotNet.Attributes;

namespace Benchmarks.StructsAsInterface;


/// <summary>
/// | Method             | Mean      | Error     | StdDev    |
//  |------------------- |----------:|----------:|----------:| 
//  | BenchmarkInterface | 2.8557 ns | 0.0120 ns | 0.0112 ns |
//  | BenchmarkStruct    | 0.4045 ns | 0.0033 ns | 0.0031 ns |
/// </summary>
public class BenchmarkStructs
{
    private readonly DoStuff _stuff = new();

    [Benchmark]
    public void BenchmarkInterface() => RunAsInterface(_stuff);

    [Benchmark]
    public void BenchmarkStruct() => RunAsStruct(_stuff);

    private static void RunAsInterface(IDoStuff stuff) => stuff.Do();
    private static void RunAsStruct(DoStuff stuff) => stuff.Do();
}

internal struct DoStuff : IDoStuff
{
    public int Do() => 1;
}

internal interface IDoStuff
{
    int Do();
}