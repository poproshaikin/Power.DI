namespace Power.DI;

public partial class ServiceProvider
{
    public void AddSingleton<TService, TImpl>(string? key = null) where TService : class where TImpl : class, TService
    {
        throw new NotImplementedException();
    }

    public void AddSingleton<TImpl>(string? key = null) where TImpl : class
    {
        throw new NotImplementedException();
    }

    public void AddTransient<TService, TImpl>(string? key = null) where TService : class where TImpl : class, TService
    {
        throw new NotImplementedException();
    }

    public void AddTransient<TImpl>(string? key = null) where TImpl : class
    {
        throw new NotImplementedException();
    }

    public void AddScoped<TService, TImpl>(string? key = null) where TService : class where TImpl : class, TService
    {
        throw new NotImplementedException();
    }

    public void AddScoped<TImpl>(string? key = null) where TImpl : class
    {
        throw new NotImplementedException();
    }

    public void AddFactory<TService, TImpl>(Func<TImpl> factory) where TImpl : class, TService
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