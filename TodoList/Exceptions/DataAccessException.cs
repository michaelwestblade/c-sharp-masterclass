namespace Exceptions;

public class DataAccessException: Exception
{
    public DataAccessException(){}
    
    public DataAccessException(string message): base(message){}
}