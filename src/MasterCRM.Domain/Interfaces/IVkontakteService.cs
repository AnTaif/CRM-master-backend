namespace MasterCRM.Domain.Interfaces;

public interface IVkontakteService
{
    public Task<ExchangeTokenResponse?> ExchangeSilentTokenWithPayloadAsync(string queryPayload);

    public Task<ExchangeTokenResponse?> ExchangeSilentTokenAsync(string silentToken, string uuid);

    public Task<VkProfileResponse?> GetProfileInfoAsync(string accessToken);
}

public record ExchangeTokenResponse(string AccessToken, int UserId, string? Email, string? Phone);

public record VkProfileResponse(string FirstName, string LastName, string ScreenName);