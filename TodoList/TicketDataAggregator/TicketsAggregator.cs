using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

namespace TicketDataAggregator;

public class TicketsAggregator
{
   private readonly string _ticketsFolder;
   
   public TicketsAggregator(string ticketsFolder)
   {
       _ticketsFolder = ticketsFolder;
   }
   
   public void Run()
   {
       foreach (var filePath in Directory.GetFiles(_ticketsFolder, "*.pdf"))
       {
           using PdfDocument document = PdfDocument.Open(filePath);
           Page page = document.GetPage(1);
           string text = page.Text;
           var split = text.Split(new[] {"Title:", "Date:", "Time:", "Visit us:"}, StringSplitOptions.None);

           for (int i = 0; i < split.Length - 3; i += 3)
           {
               var title = split[i];
               var date = split[i + 1];
               var time = split[i + 2];
               
           }
       }
   }
}