namespace Exceptions;

public class JsonParsingException: Exception
{
    public string JsonBody { get; }
    
    public JsonParsingException()
    {
    }
    
    public JsonParsingException(string message): base(message)
    {
    }
    
    public JsonParsingException(string message, string jsonBody, Exception innerException): base(message)
    {
        JsonBody = jsonBody;
    }
}