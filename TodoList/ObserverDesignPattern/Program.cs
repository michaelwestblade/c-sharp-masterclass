// See https://aka.ms/new-console-template for more information

using ObserverDesignPattern;

const int threshold = 30_000;

var emailPriceChangeNotifier = new EmailPriceChangeNotifier(threshold);
var goldPriceReader = new GoldPriceReader();

goldPriceReader.AttachObserver(emailPriceChangeNotifier);

for (int i = 0; i < 3; ++i)
{
    goldPriceReader.ReadCurrentPrice();
}