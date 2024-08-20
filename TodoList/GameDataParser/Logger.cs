namespace GameDataParser;

public class Logger
{
    private readonly string _logFileName;

    public Logger(string logFileName)
    {
        _logFileName = logFileName;
    }

    public void log(Exception e)
    {
        var entry = $@"[{DateTime.Now}]
Exception message: {e.Message}
Stack trace: {e.StackTrace}
Source: {e.Source}TargetSite: {e.TargetSite}
        
        ";
        File.AppendAllText(_logFileName, entry);
    }
}