namespace MasterCRM.Application.Services.Websites.Constructor.Responses;

public record GlobalStylesDto
{
    public required string FontFamily { get; init; }

    public required string BackgroundColor { get; init; }

    public required string H1Color { get; init; }

    public required string PColor { get; init; }

    public required string ButtonColor { get; init; }
}