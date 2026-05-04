using System.Net.Http.Headers;
using System.Text.Json;
using AIAssistant.Models;

namespace AIAssistant
{
    public class AiService : IAiService
    {
        private readonly HttpClient _httpClient;

        public AiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ErrorResponse> AnalyzeError(string error)
        {
            var prompt = $@"
You are a senior .NET developer.
Analyze this error and provide:
1. Simple explanation
2. Root cause
3. Fix in code

Error:
{error}
";

            var requestBody = new
            {
                model = "gpt-4o-mini",
                messages = new[]
                {
                    new { role = "system", content = "You are a helpful .NET expert." },
                    new { role = "user", content = prompt }
                }
            };

       
            var response = await _httpClient.PostAsJsonAsync(
                "https://api.openai.com/v1/chat/completions",
                requestBody
            );

            // ❌ Check response first
            var json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"OpenAI Error: {json}");
            }

            // ✅ Safe parsing
            var result = JsonSerializer.Deserialize<OpenAiResponse>(json);

            var content = result?
                .choices?
                .FirstOrDefault()?
                .message?
                .content;

            return new ErrorResponse
            {
                Solution = content ?? "No AI response returned"
            };
        }
    }
}