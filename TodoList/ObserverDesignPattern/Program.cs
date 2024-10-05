// See https://aka.ms/new-console-template for more information

using ObserverDesignPattern;

const int threshold = 30_000;

var emailPriceChangeNotifierObserver = new EmailPriceChangeNotifierObserver(threshold);
var pushPriceChangeNotifierObserver = new PushPriceChangeNotifierObserver(threshold);
var goldPriceReaderObservable = new GoldPriceReaderObservable();

goldPriceReaderObservable.AttachObserver(emailPriceChangeNotifierObserver);
goldPriceReaderObservable.AttachObserver(pushPriceChangeNotifierObserver);

for (int i = 0; i < 3; ++i)
{
    goldPriceReaderObservable.ReadCurrentPrice();
}

goldPriceReaderObservable.DetachObserver(emailPriceChangeNotifierObserver);
goldPriceReaderObservable.DetachObserver(pushPriceChangeNotifierObserver);

var goldPriceReader = new GoldPriceReader();
var emailPriceChangeNotifier = new EmailPriceChangeNotifier(threshold);
var pushPriceChangeNotifier = new PushPriceChangeNotifier(threshold);
goldPriceReader.PriceRead += emailPriceChangeNotifier.Update;
goldPriceReader.PriceRead += pushPriceChangeNotifier.Update;

for (int i = 0; i < 3; ++i)
{
    goldPriceReader.ReadCurrentPrice();
}

goldPriceReader.PriceRead -= emailPriceChangeNotifier.Update;
goldPriceReader.PriceRead -= pushPriceChangeNotifier.Update;