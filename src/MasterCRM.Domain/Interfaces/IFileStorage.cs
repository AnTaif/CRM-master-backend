namespace MasterCRM.Domain.Interfaces;

public interface IFileStorage
{
    Task<string> UploadAsync(Stream stream, string fileName);
    
    bool TryDelete(string path);
}