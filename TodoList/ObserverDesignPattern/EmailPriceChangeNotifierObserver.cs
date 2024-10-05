namespace ObserverDesignPattern;

public class EmailPriceChangeNotifierObserver: IObserver<decimal>
{
    private readonly decimal _notificationThreshold;

    public EmailPriceChangeNotifierObserver(decimal notificationThreshold)
    {
        _notificationThreshold = notificationThreshold;
    }

    public void Update(decimal price)
    {
        if (price > _notificationThreshold)
        {
            Console.WriteLine($"Sending email saying that the price of gold exceeded {_notificationThreshold} and is now {price}");
        }
    }
}