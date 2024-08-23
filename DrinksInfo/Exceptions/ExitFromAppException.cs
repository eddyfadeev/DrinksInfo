namespace DrinksInfo.Exceptions;

public class ExitApplicationException : Exception
{
    public ExitApplicationException() : base("Exiting the application.")
    {
    }
    
    public ExitApplicationException(string message) : base(message)
    {
    }
    
    public ExitApplicationException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

public class ReturnToPreviousMenuException : Exception
{
    public ReturnToPreviousMenuException() : base("Returning to the previous menu.")
    {
    }
    
    public ReturnToPreviousMenuException(string message) : base(message)
    {
    }
    
    public ReturnToPreviousMenuException(string message, Exception innerException) : base(message, innerException)
    {
    }
}