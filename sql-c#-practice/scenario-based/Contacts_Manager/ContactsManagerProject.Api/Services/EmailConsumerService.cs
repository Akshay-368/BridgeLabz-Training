using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using MailKit.Net.Smtp;
using MimeKit;

namespace ContactsManagerProject.Api.Services;

public class EmailConsumerService : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost"
        };

        var connection = await factory.CreateConnectionAsync(stoppingToken);
        var channel = await connection.CreateChannelAsync(cancellationToken: stoppingToken);

        await channel.QueueDeclareAsync(
            queue: "welcome-email-queue",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null,
            cancellationToken: stoppingToken);

        var consumer = new AsyncEventingBasicConsumer(channel);

        consumer.ReceivedAsync += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var json = Encoding.UTF8.GetString(body);

            var data = JsonSerializer.Deserialize<EmailMessage>(json);

            if (data != null)
            {
                await SendEmailAsync(data.Email, data.Name);
            }

            await channel.BasicAckAsync(ea.DeliveryTag, false, stoppingToken);
        };

        await channel.BasicConsumeAsync(
            queue: "welcome-email-queue",
            autoAck: false,
            consumer: consumer,
            cancellationToken: stoppingToken);

        // Keep background service alive
        await Task.Delay(Timeout.Infinite, stoppingToken);
    }

    private async Task SendEmailAsync(string email, string name)
    {
        var message = new MimeMessage();
        message.From.Add(MailboxAddress.Parse("gargakshay2004@gmail.com"));
        message.To.Add(MailboxAddress.Parse(email));
        message.Subject = "Welcome!";
        message.Body = new TextPart("plain")
        {
            Text = $"Hello {name}, welcome to Contacts Manager!"
        };

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync("smtp.gmail.com", 587, false);
        await smtp.AuthenticateAsync("gargakshay2004@gmail.com", "wsspvpkeusdjmvdi");
        await smtp.SendAsync(message);
        await smtp.DisconnectAsync(true);
    }
}

public class EmailMessage
{
    public string Email { get; set; } = "";
    public string Name { get; set; } = "";
}