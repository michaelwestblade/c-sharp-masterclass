namespace ObserverDesignPattern;

public class GoldPriceReader: IObservable<decimal>
{
    private int _currentGoldPrice;
    private readonly List<IObserver<decimal>> _observers = [];

    public void ReadCurrentPrice()
    {
        _currentGoldPrice = new Random().Next(20_000, 50_000);
        NotifyObservers();
    }

    public void AttachObserver(IObserver<decimal> observer)
    {
        _observers.Add(observer);
    }

    public void DetachObserver(IObserver<decimal> observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update( _currentGoldPrice);
        }
    }
}