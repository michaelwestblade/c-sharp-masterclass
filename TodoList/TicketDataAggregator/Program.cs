// See https://aka.ms/new-console-template for more information

using TicketDataAggregator;

const string TicketsFolder = "Tickets";

try
{
    var ticketsAggregator = new TicketsAggregator(TicketsFolder);

    ticketsAggregator.Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.ReadKey();