namespace Power.DI;

internal class SingletonServicesCollection : IServiceCollection
{
    private readonly List<ServiceBase> _services;

    internal SingletonServicesCollection()
    {
        _services = [];
    }
    
    public void Add<TService, TImplementation>(string? key = null) where TService : class where TImplementation : class, TService
    {
        throw new NotImplementedException();
    }

    public void Add<TImplementation>(string? key = null) where TImplementation : class
    {
        throw new NotImplementedException();
    }

    public TService Resolve<TService>(string? key = null) where TService : class
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TService> ResolveAll<TService>() where TService : class
    {
        throw new NotImplementedException();
    }
}