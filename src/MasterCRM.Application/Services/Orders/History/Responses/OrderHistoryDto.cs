namespace MasterCRM.Application.Services.Orders.History.Responses;

public record OrderHistoryDto(string Type, string Change, DateTime Date);