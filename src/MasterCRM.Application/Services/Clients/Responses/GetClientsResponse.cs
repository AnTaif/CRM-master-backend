namespace MasterCRM.Application.Services.Clients.Responses;

public record GetClientsResponse(int Count, IEnumerable<ClientItemResponse> Clients);