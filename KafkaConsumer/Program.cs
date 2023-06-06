using Confluent.Kafka;

var config = new ConsumerConfig
{
    BootstrapServers = "124.70.40.236:22102", // Kafka集群的地址
    GroupId = "my_consumer_group",        // 设置groupid
    AutoOffsetReset = AutoOffsetReset.Earliest, // 设置消费者在启动时从哪个偏移量开始消费
    EnableAutoCommit = false                     // 禁用自动提交偏移量
};

using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
{
    consumer.Subscribe("drive_data_signal");

    while (true)
    {
        var message = consumer.Consume();
        Console.WriteLine($"Received message: {message.Value}");
    }
}