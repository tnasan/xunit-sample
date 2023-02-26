namespace Sample.Repositories.Interfaces;

public interface ISampleRepository
{
    Task<int> Plus(int value1, int value2);
    Task<double> Divide(double value1, int value2);
}