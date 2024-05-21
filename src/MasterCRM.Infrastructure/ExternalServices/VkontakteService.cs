using System.Text.Json.Nodes;
using MasterCRM.Domain.Interfaces;

namespace MasterCRM.Infrastructure.ExternalServices;

public class VkontakteService(string apiVersion, string serviceToken) : IVkontakteService
{
    private const string vkApiMethodBase = "https://api.vk.com/method/"; 
    
    public async Task<ExchangeTokenResponse?> ExchangeSilentTokenAsync(string queryPayload)
    {
        var payload = JsonNode.Parse(queryPayload);

        if (payload == null)
            throw new Exception();
        
        var silentToken = payload["token"]?.ToString();
        var uuid = payload["uuid"]?.ToString();

        if (silentToken == null || uuid == null)
            throw new Exception();
        
        using var client = new HttpClient();

        var queryParams = new[]
        {
            ("v", apiVersion), ("token", silentToken), ("access_token", serviceToken), ("uuid", uuid)
        };
        var url = BuildUrl("auth.exchangeSilentAuthToken", queryParams);
        
        var responseJson = await GetJsonResponseAsync(client, url);

        if (responseJson == null)
            return null;
        
        var accessToken = responseJson["access_token"]?.ToString();
        var userId = responseJson["user_id"]?.ToString();
        var email = responseJson["email"]?.ToString();

        if (accessToken == null || userId == null)
            return null;
        
        return new ExchangeTokenResponse(accessToken, int.Parse(userId), email, null);
    }
    
    public async Task<VkProfileResponse?> GetProfileInfoAsync(string accessToken)
    {
        using var client = new HttpClient();

        var queryParams = new[]
        {
            ("v", apiVersion), ("access_token", accessToken)
        };
        var url = BuildUrl("account.getProfileInfo", queryParams);

        var profileInfo = await GetJsonResponseAsync(client, url);

        if (profileInfo == null)
            return null;

        var firstName = profileInfo["first_name"]?.ToString();
        var lastName = profileInfo["last_name"]?.ToString();
        var screenName = profileInfo["screen_name"]?.ToString();

        if (firstName == null || lastName == null || screenName == null)
            return null;

        return new VkProfileResponse(firstName, lastName, screenName);
    }
    
    private async Task<JsonNode?> GetJsonResponseAsync(HttpClient client, string url)
    {
        var response = await client.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return null;

        var body = await response.Content.ReadAsStringAsync();
        return JsonNode.Parse(body)?["response"];
    }

    private string BuildUrl(string method, params (string, string)[] parameters)
    {
        var query = string.Join("&", parameters.Select(p => $"{p.Item1}={Uri.EscapeDataString(p.Item2)}"));
        return vkApiMethodBase + method + $"?{query}";
    }
}