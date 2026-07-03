using System;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Protocol;

namespace GS1.MySQL
{
    internal class MqttService
    {
        private IMqttClient client;
        private string subscribeTopic;
        private Func<MqttClientConnectedEventArgs, Task> connectedHandler;
        private Func<MqttClientDisconnectedEventArgs, Task> disconnectedHandler;
        private Func<MqttApplicationMessageReceivedEventArgs, Task> messageReceivedHandler;

        public event Action<string> OnMessageReceived;
        public event Action<string> OnStatusChanged;

        public bool IsConnected => client != null && client.IsConnected;

        public async Task ConnectAsync()
        {
            if (IsConnected)
                return;

            // Cho phép đổi broker/topic từ App.config để demo linh hoạt.
            string host = ConfigurationManager.AppSettings["MqttHost"] ?? "broker.hivemq.com";
            int port = 1883;
            int.TryParse(ConfigurationManager.AppSettings["MqttPort"], out port);
            if (port <= 0) port = 1883;

            subscribeTopic = ConfigurationManager.AppSettings["MqttTopic"] ?? "gs1/scan";
            string clientId = ConfigurationManager.AppSettings["MqttClientId"];
            if (string.IsNullOrWhiteSpace(clientId))
                clientId = "GS1-WinForms-" + Guid.NewGuid().ToString("N").Substring(0, 8);

            var factory = new MqttFactory();
            var mqttClient = factory.CreateMqttClient();
            client = mqttClient;

            // Sau khi kết nối thành công thì subscribe topic nhận mã GS1.
            connectedHandler = async e =>
            {
                if (mqttClient == null || !mqttClient.IsConnected)
                    return;

                await mqttClient.SubscribeAsync(new MqttTopicFilterBuilder()
                    .WithTopic(subscribeTopic)
                    .WithQualityOfServiceLevel(MqttQualityOfServiceLevel.AtLeastOnce)
                    .Build());

                OnStatusChanged?.Invoke("MQTT connected");
            };
            mqttClient.ConnectedAsync += connectedHandler;

            disconnectedHandler = e =>
            {
                OnStatusChanged?.Invoke("MQTT disconnected");
                return Task.CompletedTask;
            };
            mqttClient.DisconnectedAsync += disconnectedHandler;

            messageReceivedHandler = e =>
            {
                // Payload sẽ được bắn về Form Scan/Add thông qua event.
                var payload = e.ApplicationMessage?.Payload == null
                    ? string.Empty
                    : Encoding.UTF8.GetString(e.ApplicationMessage.Payload);

                if (!string.IsNullOrWhiteSpace(payload))
                    OnMessageReceived?.Invoke(payload.Trim());

                return Task.CompletedTask;
            };
            mqttClient.ApplicationMessageReceivedAsync += messageReceivedHandler;

            var builder = new MqttClientOptionsBuilder()
                .WithClientId(clientId)
                .WithTcpServer(host, port)
                .WithCleanSession();

            string username = ConfigurationManager.AppSettings["MqttUsername"];
            string password = ConfigurationManager.AppSettings["MqttPassword"];
            if (!string.IsNullOrWhiteSpace(username))
                builder.WithCredentials(username, password ?? string.Empty);

            await mqttClient.ConnectAsync(builder.Build());
        }

        public async Task DisconnectAsync()
        {
            var mqttClient = client;
            if (mqttClient == null)
                return;

            if (connectedHandler != null)
                mqttClient.ConnectedAsync -= connectedHandler;
            if (disconnectedHandler != null)
                mqttClient.DisconnectedAsync -= disconnectedHandler;
            if (messageReceivedHandler != null)
                mqttClient.ApplicationMessageReceivedAsync -= messageReceivedHandler;

            connectedHandler = null;
            disconnectedHandler = null;
            messageReceivedHandler = null;

            if (mqttClient.IsConnected)
                await mqttClient.DisconnectAsync();

            mqttClient.Dispose();
            client = null;
        }
    }
}