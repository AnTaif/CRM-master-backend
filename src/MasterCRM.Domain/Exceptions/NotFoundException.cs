namespace MasterCRM.Domain.Exceptions;

public class NotFoundException(string text) : Exception(text)
{
    
}