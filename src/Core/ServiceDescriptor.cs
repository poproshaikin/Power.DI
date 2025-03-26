using System.Reflection;

namespace Power.DI;

public class ServiceDescriptor
{
    public Type ServiceType { get; }

    internal bool BaseTypeIsInterface => ServiceType.IsInterface;
    
    public List<Type> ImplementationTypes { get; }
    
    public ServiceLifetime Lifetime { get; }
    
    internal ConstructorInfo? Constructor => ServiceType.GetConstructor(Type.EmptyTypes);
    
    internal bool HasConstructor => Constructor is not null;

    internal bool HasParameterlessConstructor => HasConstructor && Constructor!.GetParameters().Length == 0;

    internal ServiceDescriptor(ServiceLifetime lifetime,
        Type serviceType,
        Type[]? implementationTypes)
    {
        ServiceType = serviceType;
        ImplementationTypes = implementationTypes?.ToList() ?? [];
        Lifetime = lifetime;
    }

    internal void AddImplementationType(Type implementationType)
    {
        ImplementationTypes.Add(implementationType);
    }
}