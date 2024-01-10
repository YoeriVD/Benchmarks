using BenchmarkDotNet.Attributes;

namespace Benchmarks.OverEngineering;
/// <summary>
/// | Method             | Position | Mean      | Error     | StdDev    |
/// |------------------- |--------- |----------:|----------:|----------:|
/// | BenchmarkSwitch    | 1        | 0.6512 ns | 0.0040 ns | 0.0035 ns |
/// | BenchmarkFancy     | 1        | 0.4117 ns | 0.0032 ns | 0.0030 ns |
/// | BenchmarkUberFancy | 1        | 0.0000 ns | 0.0000 ns | 0.0000 ns |
/// | BenchmarkSwitch    | 5        | 0.8099 ns | 0.0029 ns | 0.0027 ns |
/// | BenchmarkFancy     | 5        | 0.4083 ns | 0.0018 ns | 0.0016 ns |
/// | BenchmarkUberFancy | 5        | 0.0000 ns | 0.0000 ns | 0.0000 ns |
/// | BenchmarkSwitch    | 9        | 0.8083 ns | 0.0018 ns | 0.0016 ns |
/// | BenchmarkFancy     | 9        | 0.4088 ns | 0.0039 ns | 0.0036 ns |
/// | BenchmarkUberFancy | 9        | 0.0000 ns | 0.0000 ns | 0.0000 ns |
/// </summary>
public class SwitchVsCalculate
{
    private readonly (int, int)[] Coords =
    {
        (0, 0), (0, 1), (0, 2), (1, 0), (1, 1), (1, 2), (2, 0), (2, 1), (2, 2)
    };

    [Params(1, 5, 9)] public int Position { get; set; }

    [Benchmark]
    public void BenchmarkSwitch() => GetCoords(Position);

    [Benchmark]
    public void BenchmarkFancy() => GetFancyCoords(Position);
    
    [Benchmark]
    public void BenchmarkUberFancy() => GetUberFancyCoords(Position);

    private (int, int) GetCoords(int position) => position switch
    {
        1 => (0, 0),
        2 => (0, 1),
        3 => (0, 2),
        4 => (1, 0),
        5 => (1, 1),
        6 => (1, 2),
        7 => (2, 0),
        8 => (2, 1),
        9 => (2, 2),
        _ => throw new ArgumentException()
    };

    private (int, int) GetFancyCoords(int position) => ((position - 1) / 3, (position - 1) % 3);

    private (int, int) GetUberFancyCoords(int position) => Coords[position - 1];
}