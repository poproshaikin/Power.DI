namespace Power.DI;

public interface IPowerServiceProvider : IServiceProvider
{
    void AddSingleton<TService, TImpl>(string? key = null) where TService : class where TImpl : class, TService;
    
    void AddSingleton<TImpl>(string? key = null) where TImpl : class;
    
    void AddSingleton(Type serviceType, Type implType, string? key = null);
    
    void AddSingleton(Type implType, string? key = null);
    
    void AddTransient<TService, TImpl>(string? key = null) where TService : class where TImpl : class, TService;
    
    void AddTransient<TImpl>(string? key = null) where TImpl : class;
    
    void AddTransient(Type serviceType, Type implType, string? key = null);
    
    void AddTransient(Type implType, string? key = null);
    
    void AddScoped<TService, TImpl>(string? key = null) where TService : class where TImpl : class, TService;
    
    void AddScoped<TImpl>(string? key = null) where TImpl : class;
    
    void AddScoped(Type serviceType, Type implType, string? key = null);
    
    void AddScoped(Type implType, string? key = null);
    
    void AddFactory<TService, TImpl>(Func<TImpl> factory) where TImpl : class, TService;

    void AddFactory(Type serviceType, Type implType, Func<object> factory);
    
    TService Resolve<TService>(string? key = null) where TService : class;
    
    object Resolve(Type serviceType, string? key = null);
    
    IEnumerable<TService> ResolveAll<TService>() where TService : class;

    IEnumerable<object> ResolveAll(Type serviceType);
}
