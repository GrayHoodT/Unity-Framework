using System.Collections.Generic;
using UnityEngine;

public abstract class GameEvent<T> : ScriptableObject
{
    [Multiline(5)]
    [SerializeField]
    private string desc;

    [SerializeField]
    private List<GameEventListenable<T>> listeners;

    public void Subscribe(GameEventListenable<T> element)
    {
        if (listeners.Contains(element) == true)
            return;

        listeners.Add(element);
    }
    public bool UnSubscribe(GameEventListenable<T> element)
    {
        return listeners.Remove(element);
    }

    public void Raise(object sender, T eventArgs)
    {
        foreach (GameEventListenable<T> listener in listeners)
        {
            listener.Respond(sender, eventArgs);
        }
    }
}