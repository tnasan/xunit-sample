using Sample.Repositories.Interfaces;

namespace Sample.Repositories;

public class SampleRepository : ISampleRepository
{
    public async Task<double> Divide(double value1, int value2)
    {
        var result = value1 / value2;
        return await Task.FromResult(result);
    }

    public async Task<int> Plus(int value1, int value2)
    {
        var result = value1 + value2;
        return await Task.FromResult(result);
    }
}