namespace DrinksInfo.Exceptions;

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