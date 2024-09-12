using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class GenericEventChannelSO<T> : DescriptionSO
{
    public UnityAction<T> OnEventRaised;

    public void RaiseEvent(T parameter)
    {
        if (OnEventRaised != null)
            return;

        OnEventRaised.Invoke(parameter);
    }
}
