// See https://aka.ms/new-console-template for more information

var countryToCurrencyMapping = new Dictionary<string, string>()
{
    {"USA","USD"},
    {"UK","GBP"},
    {"FRA","EUR"},
};

countryToCurrencyMapping.Add("IND","INR");
countryToCurrencyMapping.Add("SPA","EUR");

Console.WriteLine($"The currency in Spain is {countryToCurrencyMapping["SPA"]}");

Console.ReadKey();