// See https://aka.ms/new-console-template for more information
using Google.Protobuf.WellKnownTypes;
using MqttProtobufConsole;

// MQTT broker details
var serverUrl = "localhost";
var port = 1883;

// MQTT topic to publish message to
var topic = "proto_test";

// Protobuf message to publish
var dm = new DeviceMessage()
{
    Name = "PV.123",
    Reading = "22.5",
    Timestamp = ""+DateTime.Now,
    Message = "Test Proto Message 1"
};


var client = new MqttProtoClient(serverUrl, port);

await client.Publish(dm, topic, CancellationToken.None);