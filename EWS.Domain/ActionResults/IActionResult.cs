namespace EWS.Domain.ActionResults
{
    public interface IActionResult
    {
        void SetResultMessage(string message);
        ActionResultEnum ResultType{ get; }
        bool ActionSuccessful { get; }
        bool ActionCompleted { get; }
        string ResultMessage { get; }
    }

}
