namespace Power.DI;

public partial class ServiceCollection
{
    void IServiceCollection.Add<TService, TImplementation>(string? key) =>
        Add<TService, TImplementation>(key);

    void IServiceCollection.Add<TImplementation>(string? key) => Add<TImplementation>(key);
}