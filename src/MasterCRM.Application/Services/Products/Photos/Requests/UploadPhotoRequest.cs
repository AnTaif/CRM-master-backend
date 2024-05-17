namespace MasterCRM.Application.Services.Products.Photos.Requests;

public record UploadPhotoRequest(Stream PhotoStream, string Extension);