using System.Collections.Generic;

public static class EventBus<T> where T : IEvent
{
    private static HashSet<IEventListener<T>> listeners = new HashSet<IEventListener<T>>();

    public static void Add(IEventListener<T> listener) => listeners.Add(listener);
    public static void Romve(IEventListener<T> listener) => listeners.Remove(listener);

    public static void Raise(T parameter)
    {
        foreach (var listener in listeners)
            listener.Response.Invoke(parameter);
    }
}
