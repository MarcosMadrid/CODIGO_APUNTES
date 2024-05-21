using Amazon.SQS;
using Amazon.SQS.Model;
using MvcCoreSenderAWSSQS.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace MvcCoreSenderAWSSQS.Services
{
    public class ServiceSQS
    {
        private string UrlQueue;
        private IAmazonSQS amazonSQS;

        public ServiceSQS(IAmazonSQS amazonSQS, IConfiguration configuration)
        {
            this.UrlQueue = configuration.GetValue<string>("urlQueue")!;
            this.amazonSQS = amazonSQS;
        }

        public async Task SendMessageAsync(Mensaje mensaje)
        {
            string json = JsonConvert.SerializeObject(mensaje);
            SendMessageRequest sendMessage = new SendMessageRequest(this.UrlQueue, json);
            SendMessageResponse messageResponse = await this.amazonSQS.SendMessageAsync(sendMessage);
        }

        public async Task<List<Mensaje>> RecieveMessagesAsync()
        {
            ReceiveMessageRequest messageResponse = new ReceiveMessageRequest()
            {
                QueueUrl = this.UrlQueue,
                MaxNumberOfMessages = 5,
                WaitTimeSeconds = 15,
            };

            ReceiveMessageResponse response = await this.amazonSQS.ReceiveMessageAsync(messageResponse);
            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                List<Mensaje> messages = new List<Mensaje>();   
                foreach (Message message in response.Messages.ToList())
                {
                    string json = message.Body;
                    Mensaje mensaje = JsonConvert.DeserializeObject<Mensaje>(json)!;
                    mensaje.ReceiptHandle = message.ReceiptHandle;
                    messages.Add(mensaje);
                }
                return messages;
            }
            else
            {
                throw new Exception(response.HttpStatusCode + " | " + response.ResponseMetadata.ToString());
            }
        }

        public async Task DeleteMessage(string receiptHandle)
        {
            DeleteMessageRequest request = new DeleteMessageRequest() 
            { 
                ReceiptHandle = receiptHandle ,
                QueueUrl = this.UrlQueue,
            };
            DeleteMessageResponse response =
                await this.amazonSQS.DeleteMessageAsync(request);
            HttpStatusCode statusCode = response.HttpStatusCode;

        }
    }
}
