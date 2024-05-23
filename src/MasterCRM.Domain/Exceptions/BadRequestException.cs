namespace MasterCRM.Domain.Exceptions;

public class BadRequestException(string? text) : Exception(text);