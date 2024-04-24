using System.Text.Json.Nodes;
using MasterCRM.Domain.Interfaces;

namespace MasterCRM.Infrastructure.ExternalServices;

public class VkontakteService(string apiVersion, string serviceToken) : IVkontakteService
{
    public async Task<ExchangeTokenResponse?> ExchangeSilentTokenAsync(string silentToken, string uuid)
    {
        using var client = new HttpClient();
        
        var query = $"v={apiVersion}&token={silentToken}&access_token={serviceToken}&uuid={uuid}";
        var url = $"https://api.vk.com/method/auth.exchangeSilentAuthToken?{query}";

        var response = await client.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return null;

        var body = await response.Content.ReadAsStringAsync();
        var responseJson = JsonNode.Parse(body)?["response"];

        if (responseJson == null)
            return null;
        
        var accessToken = responseJson["access_token"]?.ToString();
        var userId = responseJson["user_id"]?.ToString();
        var email = responseJson["email"]?.ToString();

        if (accessToken == null || userId == null || email == null)
            return null;
        
        return new ExchangeTokenResponse(accessToken, int.Parse(userId), email, null);
    }
    
    public async Task<VkProfileResponse?> GetProfileInfoAsync(string accessToken)
    {
        using var client = new HttpClient();
        
        var query = $"v={apiVersion}&access_token={accessToken}";
        var url = $"https://api.vk.com/method/account.getProfileInfo?{query}";

        var response = await client.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return null;

        var body = await response.Content.ReadAsStringAsync();
        var profileInfo = JsonNode.Parse(body)?["response"];

        if (profileInfo == null)
            return null;

        var firstName = profileInfo["first_name"]?.ToString();
        var lastName = profileInfo["last_name"]?.ToString();
        var screenName = profileInfo["screen_name"]?.ToString();

        if (firstName == null || lastName == null || screenName == null)
            return null;

        return new VkProfileResponse(firstName, lastName, screenName);
    }
}