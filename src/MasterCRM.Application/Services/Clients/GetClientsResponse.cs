namespace MasterCRM.Application.Services.Clients;

public record GetClientsResponse(int Count, IEnumerable<ClientItemResponse> Clients);