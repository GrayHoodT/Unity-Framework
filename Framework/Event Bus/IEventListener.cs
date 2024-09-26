using System;

public interface IEventListener<T>
{
    public Action<T> Response { get; set; }
}