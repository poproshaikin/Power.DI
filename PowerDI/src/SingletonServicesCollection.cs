namespace Power.NET.Core;

internal class SingletonServicesCollection : IServiceCollection
{
    public void Add<TService, TImplementation>() where TService : class where TImplementation : class, TService
    {
        throw new NotImplementedException();
    }
}