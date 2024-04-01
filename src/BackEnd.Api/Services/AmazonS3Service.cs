using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon.Runtime;
using Amazon.S3.Model;
using BackEnd.Api.Services.Abstractions;

namespace BackEnd.Api.Services;

// todo: criar uma controller para gerenciar o s3

public class AmazonS3Service : IAmazonS3Service
{

    private readonly IAmazonS3 _s3Client;
    private readonly IConfiguration _configuration;
    private readonly ILogger<AmazonS3Service> _logger;

    public AmazonS3Service(
        IConfiguration configuration,
        ILogger<AmazonS3Service> logger)
    {
        _logger = logger;
        _configuration = configuration;

        var region = Amazon.RegionEndpoint.USEast1;
        var AccessKeyId = _configuration["AWS:Access_key_id"];
        var secretKey = _configuration["AWS:Access_key"];
        var baseUrl = _configuration["AWS:BaseLocalstackUrl"];

        var credentials = new BasicAWSCredentials(AccessKeyId, secretKey);

        var config = new AmazonS3Config
        {
            ServiceURL = baseUrl,
            ForcePathStyle = true
        };

        _s3Client = new AmazonS3Client(credentials, config);
    }

    public async Task UploadFileAsync(string bucketName, byte[] fileData, string keyName)
    {
        try
        {
            using (var memoryStream = new MemoryStream(fileData))
            {
                var fileTransferUtility = new TransferUtility(_s3Client);
                await fileTransferUtility.UploadAsync(memoryStream, bucketName, keyName);
            }
        }
        catch (AmazonS3Exception ex)
        {
            _logger.LogError($"Error on upload file to S3: {ex.Message}");
        }
    }

    public async Task DeleteImageAsync(string bucketName, string imageName)
    {

        try
        {
            var deleteObjectRequest = new DeleteObjectRequest
            {
                BucketName = bucketName,
                Key = imageName
            };

            await _s3Client.DeleteObjectAsync(deleteObjectRequest);
        }
        catch (AmazonS3Exception ex)
        {
            _logger.LogError($"Error on delete Amazon S3 file : {ex.Message}");
        }
    }

    public async Task<List<string>> ListImagesAsync(string bucketName)
    {

        try
        {
            var listObjectsRequest = new ListObjectsV2Request
            {
                BucketName = bucketName
            };

            var response = await _s3Client.ListObjectsV2Async(listObjectsRequest);

            var imageKeys = new List<string>();

            foreach (var obj in response.S3Objects)
            {
                imageKeys.Add(obj.Key);
            }

            return imageKeys;
        }
        catch (AmazonS3Exception ex)
        {
            _logger.LogError($"Error on list Amazon S3 files: {ex.Message}");
            return null!;
        }
    }
}
