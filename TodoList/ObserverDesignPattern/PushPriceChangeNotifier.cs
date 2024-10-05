namespace ObserverDesignPattern;

public class PushPriceChangeNotifier
{
    private readonly decimal _notificationThreshold;

    public PushPriceChangeNotifier(decimal notificationThreshold)
    {
        _notificationThreshold = notificationThreshold;
    }

    public void Update(object? sender, PriceReadEventArgs eventArgs)
    {
        if (eventArgs.Price > _notificationThreshold)
        {
            Console.WriteLine($"Sending push notification saying that the price of gold exceeded {_notificationThreshold} and is now {eventArgs.Price}");
        }
    }
}