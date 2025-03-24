namespace Power.DI;


public class ServiceProvider : IPowerServiceProvider 
{
    public void Add<TService, TImplementation>(string? key = null) where TService : class where TImplementation : class, TService
    {
        throw new NotImplementedException();
    }

    public void AddFactory<TService, TImpl>(Func<TImpl> factory) where TImpl : class, TService
    {
        throw new NotImplementedException();
    }

    public object Resolve(Type serviceType, string? key = null)
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
    
    object IServiceProvider.GetService(Type serviceType) => Resolve(serviceType);
}