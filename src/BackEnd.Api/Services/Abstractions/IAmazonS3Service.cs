namespace BackEnd.Api.Services.Abstractions;

public interface IAmazonS3Service
{
    Task UploadFileAsync(string bucketName, byte[] fileData, string keyName);

    Task DeleteImageAsync(string bucketName, string imageName);

    Task<List<string>> ListImagesAsync(string bucketName);

}
