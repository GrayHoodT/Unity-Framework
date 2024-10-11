using System;

public class DataNode<T>
{
    protected T value;
    protected Action<T> onValueChanged;

    public DataNode(T value)
    {
        this.value = value;
        onValueChanged = null;
    }

    public void SetValue(T value)
    {
        if (Equals(this.value, value) == true)
            return;

        this.value = value;
        onValueChanged?.Invoke(this.value);
    }
    public T GetValue() => this.value;

    public void Subscribe(Action<T> action) => onValueChanged += action;
    public void Unsubscribe(Action<T> action) => onValueChanged -= action;
}