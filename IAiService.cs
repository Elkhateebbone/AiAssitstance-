using AIAssistant.Models;

namespace AIAssistant
{
    public interface IAiService
    {
        Task<ErrorResponse> AnalyzeError(string error);
    }
}
