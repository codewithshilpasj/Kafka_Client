This is a sample try out to connect to a Confluent Kafka topic. It has 2 parts - Producer code and Consumer code. Producer code is commented out and to run Consumer code, just run it normally.
* Make sure a topic called 'topic_0' is created and the credentials of the cluster are copied correctly to the ProducerConfig and ConsumerConfig
* First, run the producer code by ncommenting the below code, check the topic if you could see any message that you have input through via command line.
* When you run the Producer code, you'll be prompt to add key value details, just give two input with some space. Eg: 76 samplemessage. No need to keep anything in quotes.
* Once its produced, check the topic if it's publish
* If yes, then comment the Producer code and uncomment the Consumer code(comment the consumer code when you run the Producer code)
* Run the consumer code and see if you can see the messages.
