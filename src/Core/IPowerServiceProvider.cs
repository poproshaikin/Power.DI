namespace Power.DI;

public interface IPowerServiceProvider : IServiceProvider
{
    ServiceDescriptor AddService(Type serviceType, ServiceLifetime lifetime);
    ServiceDescriptor AddService(Type serviceType, Type implementationType, ServiceLifetime lifetime);

    void AddFactory(Type serviceType, Func<object> factory);

    new object? GetService(Type serviceType);
}