namespace MasterCRM.Domain.Interfaces;

public interface IFileStorage
{
    Task<string> UploadAsync(Stream stream, string fileName);

    public string CopyToPublic(string templateUrl);
    
    bool TryDelete(string path);
}