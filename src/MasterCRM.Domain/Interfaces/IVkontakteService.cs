namespace MasterCRM.Domain.Interfaces;

public interface IVkontakteService
{
    public Task<ExchangeTokenResponse?> ExchangeSilentTokenAsync(string queryPayload);

    public Task<VkProfileResponse?> GetProfileInfoAsync(string accessToken);
}

public record ExchangeTokenResponse(string AccessToken, int UserId, string Email, string? Phone);

public record VkProfileResponse(string FirstName, string LastName, string ScreenName);