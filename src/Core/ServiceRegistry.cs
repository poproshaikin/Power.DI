namespace Power.DI;

internal class ServiceRegistry
{
    private readonly List<ServiceDescriptor> _services;
    private readonly Dictionary<Type, Func<object>?> _factories;
    
    internal ServiceRegistry()
    {
        _factories = new Dictionary<Type, Func<object>?>();
        _services = [];
    }
    
    internal ServiceDescriptor Add(Type serviceType,
        Type[]? implementationTypes,
        ServiceLifetime lifetime,
        Func<object>? factory)
    {
        var service = new ServiceDescriptor(lifetime, serviceType, implementationTypes);
        _services.Add(service);
        return service;
    }

    internal void AddFactory(Type serviceType, Func<object>? factory)
    { 
        _factories[serviceType] = factory;
    }

    internal Func<object>? TryGetFactory(Type serviceType) => 
        _factories.GetValueOrDefault(serviceType);
    
    internal bool TryGetFactory(Type serviceType, out Func<object>? factory) => 
        (factory = _factories.GetValueOrDefault(serviceType)) is not null;

    internal bool TryGet(Type serviceType, out ServiceDescriptor? descriptor)
        => 
            (descriptor = _services.FirstOrDefault(service => service.ServiceType == serviceType)) 
            is not null;
    
    internal bool TryGet(Type serviceType, ServiceLifetime lifetime, out ServiceDescriptor? descriptor) 
        =>
            (descriptor = _services.FirstOrDefault(d => d.Lifetime == lifetime && d.ServiceType == serviceType)) 
            is not null;
}