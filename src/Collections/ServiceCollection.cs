namespace Power.DI;

public interface IServiceCollection
{
    void Add<TService, TImplementation>(string? key = null) where TService : class where TImplementation : class, TService;
    void Add<TImplementation>(string? key = null) where TImplementation : class;
    
    TService Resolve<TService>(string? key = null) where TService : class;
    IEnumerable<TService> ResolveAll<TService>() where TService : class;
}

public partial class ServiceCollection : IServiceCollection
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
    
    public void Add<TService, TImplementation>(string? key = null, ServiceLifetime lifetime = ServiceLifetime.Singleton) 
        where TService : class
        where TImplementation : class, TService
    {
        var collection = ResolveCollectionByLifetime(lifetime);
        collection.Add<TService, TImplementation>(key);
    }

    public void Add<TImplementation>(string? key = null, ServiceLifetime lifetime = ServiceLifetime.Singleton) 
        where TImplementation : class
    {
        var collection = ResolveCollectionByLifetime(lifetime);
        collection.Add<TImplementation>(key);
    }

    public TService Resolve<TService>(string? key = null) 
        where TService : class
    {
        
    }

    public IEnumerable<TService> ResolveAll<TService>() 
        where TService : class
    {
       
    }

    private IServiceCollection ResolveCollectionByLifetime(ServiceLifetime lifetime) =>
        lifetime switch
        {
            ServiceLifetime.Singleton => _singletonsServices,
            ServiceLifetime.Transient => _transientServices,
            ServiceLifetime.Scoped => _scopedServices,

            _ => throw new ArgumentOutOfRangeException(nameof(lifetime), lifetime, null)
        };
}