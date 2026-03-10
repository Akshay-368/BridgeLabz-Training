using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace ContactsManagerProject.Api.Messaging;

public class RabbitMqPublisher
{
    private readonly ConnectionFactory _factory;

    public RabbitMqPublisher()
    {
        _factory = new ConnectionFactory()
        {
            HostName = "localhost"
        };
    }

    public async Task PublishAsync(object message)
    {
        await using var connection = await _factory.CreateConnectionAsync();
        await using var channel = await connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(
            queue: "welcome-email-queue",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var json = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(json);

        await channel.BasicPublishAsync(
            exchange: "",
            routingKey: "welcome-email-queue",
            body: body);
    }
}