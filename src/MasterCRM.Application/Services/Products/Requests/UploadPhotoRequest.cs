namespace MasterCRM.Application.Services.Products.Requests;

public record UploadPhotoRequest(Stream PhotoStream, string Extension);