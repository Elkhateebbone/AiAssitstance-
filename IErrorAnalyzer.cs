namespace AIAssistant
{
    public interface IErrorAnalyzer
    {
        Task<string> Analyze(string error);

    }
}
