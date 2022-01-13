using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Google.Protobuf;
using MQTTnet.Client.Options;
using MQTTnet.Client;
using MQTTnet;

namespace MqttProtobufConsole
{
    internal class MqttProtoClient
    {
        private IMqttClientOptions mqttOptions;
        private IMqttClient client;
        public MqttProtoClient(string mqttServerUrl, int port)
        {
            mqttOptions = new MqttClientOptionsBuilder()
                .WithTcpServer(mqttServerUrl, port)
                .Build();

            var factory = new MqttFactory();
            client = factory.CreateMqttClient();

            Console.WriteLine("Proto client");
        }

        public async Task Publish(DeviceMessage dm, string topic, CancellationToken cancellationToken)
        {           
            var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(dm.ToByteArray())
                .Build();

            await client.ConnectAsync(mqttOptions, cancellationToken);
            await client.PublishAsync(message, cancellationToken);
        }
    }
}
