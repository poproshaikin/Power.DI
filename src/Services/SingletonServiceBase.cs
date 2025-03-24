namespace Power.DI;

internal class SingletonService : ServiceBase
{
    internal bool Activated { get; private set; }

    internal object? Instance { get; private set; }

    internal SingletonService(Type serviceType)
    {
        ServiceType = serviceType;
    }
    
    internal override object? Resolve(params object[] args)
    {
        if (Activated)
            return Instance;
        
        var constructor = ServiceType.GetConstructor(Type.EmptyTypes);
        
        if (constructor is null)
            return Activator.CreateInstance(ServiceType);
        
        var constructorParams = constructor.GetParameters();
        
        if (constructorParams.Length == 0) 
            return Activator.CreateInstance(ServiceType);
        
        if (constructorParams.Any(p => p.ParameterType.IsPrimitive))
            throw new 
    }
}