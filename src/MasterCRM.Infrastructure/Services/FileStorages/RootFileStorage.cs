using MasterCRM.Domain.Interfaces;
using Microsoft.Extensions.Options;

namespace MasterCRM.Infrastructure.Services.FileStorages;

public class RootFileStorage(IOptions<UploadsSettings> uploadsSettings) : IFileStorage
{
    private string publicUploadPath => Path.Combine(uploadsSettings.Value.UploadsPath, "Public");
    private string templatesUploadPath => Path.Combine(uploadsSettings.Value.UploadsPath, "Templates");
    
    public async Task<string> UploadAsync(Stream stream, string fileName)
    {
        var filePath = Path.Combine(publicUploadPath, fileName);
        await using var fileStream = new FileStream(filePath, FileMode.Create);
        await stream.CopyToAsync(fileStream);

        return uploadsSettings.Value.UploadsUrl + fileName;
    }

    public string CopyToPublic(string templateUrl)
    {
        var filePath = Path.Combine(templatesUploadPath, Path.GetFileName(templateUrl));
        
        if (!File.Exists(filePath))
            throw new FileNotFoundException("Source file not found.", filePath);

        var destFileName = Guid.NewGuid() + Path.GetExtension(filePath);
        var destFilePath = Path.Combine(publicUploadPath, destFileName);
        
        File.Copy(filePath, destFilePath);
        return uploadsSettings.Value.UploadsUrl + destFileName;
    }

    public bool TryDelete(string url)
    {
        var filePath = Path.Combine(publicUploadPath, Path.GetFileName(url));

        if (!File.Exists(filePath))
            return false;
        
        File.Delete(filePath);
        return true;
    }
}