namespace Muscat.Application;

public class InvalidCommandException : Exception
{
    public InvalidCommandException(IReadOnlyCollection<string> validationMessages)
    {
        ValidationMessages = validationMessages;
    }

    public IReadOnlyCollection<string> ValidationMessages { get; }
}
