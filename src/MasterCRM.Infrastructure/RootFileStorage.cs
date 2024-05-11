using MasterCRM.Domain.Interfaces;

namespace MasterCRM.Infrastructure;

public class RootFileStorage(string rootPath, string uploadUrlBase) : IFileStorage
{
    private string publicUploadPath => Path.Combine(rootPath, "Public");
    private string templatesUploadPath => Path.Combine(rootPath, "Templates");
    
    public async Task<string> UploadAsync(Stream stream, string fileName)
    {
        var filePath = Path.Combine(publicUploadPath, fileName);
        await using var fileStream = new FileStream(filePath, FileMode.Create);
        await stream.CopyToAsync(fileStream);

        return uploadUrlBase + fileName;
    }

    public bool TryDelete(string url)
    {
        var filePath = Path.Combine(rootPath, Path.GetFileName(url));

        if (!File.Exists(filePath))
            return false;
        
        File.Delete(filePath);
        return true;
    }
}