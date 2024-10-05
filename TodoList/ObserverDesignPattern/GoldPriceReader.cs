namespace ObserverDesignPattern;

// public delegate void PriceRead(decimal price);

public class PriceReadEventArgs : EventArgs
{
    public decimal Price { get; }

    public PriceReadEventArgs(decimal price)
    {
        Price = price;
    }
}

public class GoldPriceReader
{
    // public event PriceRead? PriceRead;
    public event EventHandler<PriceReadEventArgs> PriceRead;

    public void ReadCurrentPrice()
    {
        var currentGoldPrice = new Random().Next(20_000, 50_000);
        
        OnPriceRead(currentGoldPrice);
    }

    private void OnPriceRead(decimal price)
    {
        PriceRead?.Invoke(this, new PriceReadEventArgs(price));
    }
}