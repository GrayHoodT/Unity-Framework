public interface IObserverable<T>
{
    void Add(IObserver<T> observer);
    void Remove(IObserver<T> observer);
    void Notify(T parameter);
}
