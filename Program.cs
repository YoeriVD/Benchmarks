// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<BenchmarkStructs>();

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