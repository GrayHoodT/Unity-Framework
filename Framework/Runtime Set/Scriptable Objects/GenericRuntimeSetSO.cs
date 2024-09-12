using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericRuntimeSetSO<T> : DescriptionSO
{
    protected List<T> itemList = new List<T>();
    public IReadOnlyList<T> ItemList => itemList;

    // Event for the editor script
    public Action ItemsChanged;

    [Header("Optional")]
    [Tooltip("Notify other objects this Runtime Set has changed")]
    [SerializeField]
    protected VoidEventChannelSO onRuntimeSetUpdated;

    protected virtual void OnEnable()
    {
        if (ItemsChanged != null)
            ItemsChanged();
    }

    public virtual void Add(T thing)
    {
        if (!itemList.Contains(thing))
            itemList.Add(thing);

        if (onRuntimeSetUpdated != null)
            onRuntimeSetUpdated.RaiseEvent();

        if (ItemsChanged != null)
            ItemsChanged();
    }

    public virtual void Remove(T thing)
    {
        if (itemList.Contains(thing))
            itemList.Remove(thing);
    }

    public virtual void Clear()
    {
        itemList.Clear();

        if (onRuntimeSetUpdated != null)
            onRuntimeSetUpdated.RaiseEvent();

        if (ItemsChanged != null)
            ItemsChanged();
    }
}
