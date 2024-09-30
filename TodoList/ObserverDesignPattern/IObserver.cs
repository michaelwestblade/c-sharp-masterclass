namespace ObserverDesignPattern;

public interface IObserver<TData>
{
    void Update(TData data);
}