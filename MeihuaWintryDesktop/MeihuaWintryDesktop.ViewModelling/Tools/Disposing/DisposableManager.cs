using System.Collections.Concurrent;
using System.Diagnostics;

namespace MeihuaWintryDesktop.ViewModelling.Tools.Disposing;
public sealed class DisposableManager : IDisposable
{
    private record struct Unit;

    private ConcurrentDictionary<IDisposable, Unit> managedObjects = new();

    public bool Add(IDisposable obj)
    {
        return this.managedObjects.TryAdd(obj, default);
    }

    public bool Remove(IDisposable obj, bool doDisposing = false)
    {
        return this.managedObjects.TryRemove(obj, out _);
    }

    public void Dispose()
    {
        var objects = this.managedObjects;
        this.managedObjects = new ConcurrentDictionary<IDisposable, Unit>();

        foreach (var obj in objects.Keys)
            obj.Dispose();
    }
}
