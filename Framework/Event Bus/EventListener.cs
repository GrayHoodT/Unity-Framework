using System;

public class EventListener<T> : IEventListener<T> where T : IEvent
{
    public Action<T> Response { get; set; }
}