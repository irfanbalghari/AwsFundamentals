using System.Text.Json;
using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using SqsPublisher;

var sqsClient = new AmazonSQSClient();

var customer = new CustomerCreated
{
    Id = Guid.NewGuid(),
    Email = "irfanbalghari@gmail.com",
    FullName = "irfan ullah",
    DateOfBirth = new DateTime(1993, 1, 1),
    GitHubUsername = "irfanbalghari"
};

var queueUrlResponse = await sqsClient.GetQueueUrlAsync("customers");

var sendMessageRequest = new SendMessageRequest
{ 
    //"https://sqs.us-east-1.amazonaws.com/041272522723/Customers",
    QueueUrl = queueUrlResponse.QueueUrl,
    MessageBody = JsonSerializer.Serialize(customer),
    MessageAttributes = new Dictionary<string, MessageAttributeValue>
    {
        {
            "MessageType", new MessageAttributeValue
            {
                DataType = "String",
                StringValue = nameof(CustomerCreated)
            }
        }
    },
    
};

var response = await sqsClient.SendMessageAsync(sendMessageRequest);

Console.WriteLine();
    
    
    
    
    
    
    
    
