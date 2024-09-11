using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class GenericEventChannelSO<T> : DescriptionSO
{
    protected UnityAction<T> onEventRaised;

    public event UnityAction<T> OnEventRaised
    {
        add => onEventRaised += value;
        remove => onEventRaised -= value;
    }

    public void RaiseEvent(T parameter)
    {
        if (onEventRaised != null)
            return;

        onEventRaised.Invoke(parameter);
    }
}
