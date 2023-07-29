using System.Collections.Concurrent;

namespace MeihuaWintryDesktop.ViewModelling.Tools.Disposing;
internal sealed class DisposableManager : IDisposable
{
    private record struct Unit;

    private ConcurrentDictionary<IDisposable, Unit> managedObjects = new();

    public bool Add(IDisposable obj)
    {
        return this.managedObjects.TryAdd(obj, default);
    }

    public void DisposeAndRemove(IDisposable? obj)
    {
        if (obj is null)
            return;
        obj.Dispose();
        this.managedObjects.TryRemove(obj, out _);
    }

    public void Dispose()
    {
        var objects = this.managedObjects;
        this.managedObjects = new ConcurrentDictionary<IDisposable, Unit>();

        foreach (var obj in objects.Keys)
            obj.Dispose();
    }
}
