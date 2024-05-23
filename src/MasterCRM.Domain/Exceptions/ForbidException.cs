namespace MasterCRM.Domain.Exceptions;

public class ForbidException(string? text) : Exception(text);