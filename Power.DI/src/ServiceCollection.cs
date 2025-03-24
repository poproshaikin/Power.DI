namespace Power.NET.Core;

public interface IServiceCollection 
{
    void Add<TService, TImplementation>() where TService : class where TImplementation : class, TService;
    
}

public class ServiceCollection : IServiceCollection
{
    private readonly SingletonServicesCollection _singletonsServices;
    private readonly TransientServicesCollection _transientServices;
    private readonly ScopedServicesCollection _scopedServices;

    public ServiceCollection()
    {
        _singletonsServices = new SingletonServicesCollection();
        _transientServices = new TransientServicesCollection();
        _scopedServices = new ScopedServicesCollection();
    }
    
    public void Add<TService, TImplementation>(ServiceLifetime lifetime) where TService : class where TImplementation : class, TService
    {
        var collection = ResolveCollectionByLifetime(lifetime);
        collection.Add<TService, TImplementation>();
    }

    void IServiceCollection.Add<TService, TImplementation>() => Add<TService, TImplementation>(ServiceLifetime.Singleton);

    private IServiceCollection ResolveCollectionByLifetime(ServiceLifetime lifetime)
    {
        return lifetime switch
        {
            ServiceLifetime.Singleton => _singletonsServices,
            ServiceLifetime.Transient => _transientServices,
            ServiceLifetime.Scoped => _scopedServices,

            _ => throw new ArgumentOutOfRangeException(nameof(lifetime), lifetime, null)
        };
    }
}