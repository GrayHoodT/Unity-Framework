using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Events/Standard/Void", order = -1)]
public class GameEvent : ScriptableObject
{
    [Multiline(5)]
    [SerializeField]
    protected string desc;

    [SerializeField]
    protected List<GameEventListener> receivers;

    public void Subscribe(GameEventListener element)
    {
        if (receivers.Contains(element) == true)
            return;

        receivers.Add(element);
    }
    public bool UnSubscribe(GameEventListener element)
    {
        return receivers.Remove(element);
    }

    public void Raise(object sender)
    {
        for (var i = receivers.Count - 1; i >= 0; i--)
        {
            receivers[i].Respond(sender);
        }
    }
}