using MasterCRM.Domain.Common;
using MasterCRM.Domain.Exceptions;
using MasterCRM.Domain.Interfaces;
using Microsoft.Extensions.Options;

namespace MasterCRM.Infrastructure.Services.FileStorages;

public class RootFileStorage(IOptions<UploadsSettings> uploadsSettings) : IFileStorage
{
    private string uploadsPath => uploadsSettings.Value.UploadsPath;
    private string uploadsUrl => uploadsSettings.Value.UploadsUrl;
    private string websitesUrl => uploadsSettings.Value.WebsitesUrl;
    
    private string publicUploadPath => Path.Combine(uploadsPath, "Public");
    private string templatesUploadPath => uploadsSettings.Value.TemplatesPath;
    private string websitesUploadPath => Path.Combine(uploadsPath, "Websites");
    
    public async Task<string> UploadAsync(Stream stream, string fileName)
    {
        var filePath = Path.Combine(publicUploadPath, fileName);
        await using var fileStream = new FileStream(filePath, FileMode.Create);
        await stream.CopyToAsync(fileStream);

        return GetUploadsUrl(fileName);
    }

    public string CopyToPublic(string templateUrl)
    {
        var filePath = Path.Combine(templatesUploadPath, Path.GetFileName(templateUrl));
        
        if (!File.Exists(filePath))
            throw new FileNotFoundException("Source file not found.", filePath);

        var destFileName = Guid.NewGuid() + Path.GetExtension(filePath);
        var destFilePath = Path.Combine(publicUploadPath, destFileName);
        
        File.Copy(filePath, destFilePath);
        return GetUploadsUrl(destFileName);
    }

    public async Task<string> UploadWebsiteAsync(Stream stream, string addressName)
    {
        var filePath = Path.Combine(websitesUploadPath, addressName + ".html");
        await using var fileStream = new FileStream(filePath, FileMode.Create);
        await stream.CopyToAsync(fileStream);
        
        return GetWebsitesUrl(addressName);
    }

    public bool TryDeleteWebsite(string addressName)
    {
        var filePath = Path.Combine(websitesUploadPath, addressName + ".html");

        if (!File.Exists(filePath))
            return false;
        
        File.Delete(filePath);
        return true;
    }

    public string RenameWebsite(string oldAddressName, string newAddressName)
    {
        
        var oldfilePath = Path.Combine(websitesUploadPath, oldAddressName + ".html");
        var newfilePath = Path.Combine(websitesUploadPath, newAddressName + ".html");

        if (!File.Exists(oldfilePath))
            throw new NotFoundException("Website file not found");

        if (File.Exists(newfilePath))
            throw new Exception("New AddressName not unique");
        
        File.Move(oldfilePath, newfilePath);
        return GetWebsitesUrl(newAddressName);
    }

    //TODO: delete different directories depends on url
    public bool TryDelete(string url)
    {
        var filePath = Path.Combine(publicUploadPath, Path.GetFileName(url));

        if (!File.Exists(filePath))
            return false;
        
        File.Delete(filePath);
        return true;
    }

    private string GetWebsitesUrl(string addressName)
    {
        var uri = new Uri(websitesUrl);
        var websiteUri = new Uri(uri, addressName);
        
        return websiteUri.ToString();
    }
    
    private string GetUploadsUrl(string destFileName) => uploadsUrl + destFileName;
}