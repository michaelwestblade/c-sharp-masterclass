namespace ObserverDesignPattern;

public class PushPriceChangeNotifierObserver: IObserver<decimal>
{
    private readonly decimal _notificationThreshold;

    public PushPriceChangeNotifierObserver(decimal notificationThreshold)
    {
        _notificationThreshold = notificationThreshold;
    }

    public void Update(decimal price)
    {
        if (price > _notificationThreshold)
        {
            Console.WriteLine($"Sending push notification saying that the price of gold exceeded {_notificationThreshold} and is now {price}");
        }
    }
}