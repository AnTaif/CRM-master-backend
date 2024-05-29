namespace MasterCRM.Application.Services.Websites.PublicWebsite.Responses;

public record WebsiteDto(Guid Id, string Title, string AddressName, string? Url, int? TemplateId);