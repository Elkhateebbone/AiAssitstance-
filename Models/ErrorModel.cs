namespace AIAssistant.Models
{
    public class ErrorModel
    {
        public string Message { get; set; }

    }
    public class OpenAiResponse
    {
        public Choice[] choices { get; set; }
    }

    public class Choice
    {
        public Message message { get; set; }
    }

    public class Message
    {
        public string content { get; set; }
    }
}
