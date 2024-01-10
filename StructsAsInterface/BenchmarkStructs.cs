using BenchmarkDotNet.Attributes;

namespace Benchmarks.StructsAsInterface;

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