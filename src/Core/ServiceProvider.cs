using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Power.DI;

public class ServiceProvider : IPowerServiceProvider
{
    private readonly ServiceRegistry _registry;

    private readonly SingletonServicesContainer _singletons;

    public ServiceProvider()
    {
        _registry = new ServiceRegistry();
        _singletons = new SingletonServicesContainer();
    }

    public ServiceDescriptor AddService(Type serviceType, ServiceLifetime lifetime)
    {
        var factory = _registry.TryGetFactory(serviceType);
	    return _registry.Add(serviceType, implementationTypes: null, lifetime, factory);
    }

    public ServiceDescriptor AddService(Type serviceType, Type implementationType, ServiceLifetime lifetime)
    {
        if (!_registry.TryGet(serviceType, lifetime, out var descriptor)) 
            descriptor = AddService(serviceType, lifetime);
        descriptor!.AddImplementationType(implementationType);
        
        return descriptor;
    }

    public void AddFactory(Type serviceType, Func<object> factory)
    {
        _registry.AddFactory(serviceType, factory);
    }

    public object? GetService(Type serviceType)
    {
        if (!_registry.TryGet(serviceType, out var descriptor))
            return null;

        if (_registry.TryGetFactory(serviceType, out var factory))
            return factory!();
        
        if (!descriptor!.HasConstructor || descriptor.HasParameterlessConstructor)
            return Activator.CreateInstance(serviceType);

        object? resolved = TryActivateWithDependencies(descriptor);
        
        if (resolved is not null)
            return resolved;

        ThrowCannotResolveDependency(serviceType, null);
        return null;
    }

    private object? TryActivateWithDependencies(ServiceDescriptor descriptor)
    {
        ParameterInfo[] constructorParamsInfo = descriptor.Constructor!.GetParameters();
        List<object> resolvedDependencies = [];
        
        foreach (var paramInfo in constructorParamsInfo)
        {
            Type paramType = paramInfo.ParameterType;
            
            if (paramType.IsPrimitive || paramType == typeof(string))
                ThrowCannotResolveDependency(descriptor.ServiceType, paramType);

            object? param = GetService(paramType);
            
            if (param is null)
                ThrowCannotResolveDependency(descriptor.ServiceType, paramType);
            
            resolvedDependencies.Add(param);
        }
        
        return Activator.CreateInstance(descriptor.ServiceType, resolvedDependencies);
    }

    [DoesNotReturn]
    private void ThrowCannotResolveDependency(Type serviceType, Type? dependencyType)
    {
        throw new Exception(
            $"Cannot resolve constructor dependencies for type '{serviceType}{(dependencyType is null ? "" : $": {dependencyType}")}");
    }

    object? IServiceProvider.GetService(Type serviceType) => GetService(serviceType);
}