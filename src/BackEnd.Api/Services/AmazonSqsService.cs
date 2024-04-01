using Amazon.SQS;
using Amazon.SQS.Model;
using BackEnd.Api.Services.Abstractions;

namespace BackEnd.Api.Services;

public class AmazonSqsService : IAmazonSqsService
{
    private readonly IAmazonSQS _sqsClient;
    private readonly IConfiguration _configuration;

    public AmazonSqsService(
        IAmazonSQS sqsClient,
        IConfiguration configuration)
    {
        _configuration = configuration;
        _sqsClient = sqsClient;
    }

    public async Task<string> SendMessageAsync(string message)
    {
        var request = new SendMessageRequest
        {
            QueueUrl = _configuration["AWS:QueueBikeUrl"],
            MessageBody = message
        };

        var response = await _sqsClient.SendMessageAsync(request);

        return response.MessageId;
    }

}
