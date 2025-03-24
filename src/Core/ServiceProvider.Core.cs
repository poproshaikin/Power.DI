namespace Power.DI;

public partial class ServiceProvider : IPowerServiceProvider 
{    
    public void AddSingleton(Type serviceType, Type implType, string? key = null)
    {
        throw new NotImplementedException();
    }

    public void AddSingleton(Type implType, string? key = null)
    {
        throw new NotImplementedException();
    }

    public void AddTransient(Type serviceType, Type implType, string? key = null)
    {
        throw new NotImplementedException();
    }

    public void AddTransient(Type implType, string? key = null)
    {
        throw new NotImplementedException();
    }

    public void AddScoped(Type serviceType, Type implType, string? key = null)
    {
        throw new NotImplementedException();
    }

    public void AddScoped(Type implType, string? key = null)
    {
        throw new NotImplementedException();
    }

    public void AddFactory(Type serviceType, Type implType, Func<object> factory)
    {
        throw new NotImplementedException();
    }

    public object Resolve(Type serviceType, string? key = null)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<object> ResolveAll(Type serviceType)
    {
        throw new NotImplementedException();
    }
    
    object IServiceProvider.GetService(Type serviceType) => Resolve(serviceType);
}