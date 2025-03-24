using System.Reflection.Metadata;

namespace Power.DI;

internal abstract class ServiceBase
{
    internal Type ServiceType { get; private protected set; }
    
    internal string ServiceName { get; }
    
    internal ServiceLifetime Lifetime { get; }
    
    internal abstract object? Resolve(params object[] args);
}