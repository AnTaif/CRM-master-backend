namespace MasterCRM.Domain.Interfaces;

public interface IFileStorage
{
    Task<string> UploadAsync(Stream stream, string fileName);

    public string CopyToPublic(string templateUrl);

    public Task<string> UploadWebsiteAsync(Stream stream, string addressName);

    public bool TryDeleteWebsite(string addressName);

    public string RenameWebsite(string oldAddressName, string newAddressName);
    
    bool TryDelete(string path);
}