namespace Power.DI;

internal class TransientServicesCollection : IServiceCollection
{
    public void Add<TService, TImplementation>(string? key = null) where TService : class where TImplementation : class, TService
    {
        throw new NotImplementedException();
    }
}