namespace EWS.Domain.ActionResults
{
    public class SuccessResult : IActionResult
    {

        private string _ResultMessage;

        public SuccessResult()
        {
            _ResultMessage = "Successful";
        }

        public SuccessResult(string resultMessage)
        {
            _ResultMessage = resultMessage;
        }

        public void SetResultMessage(string message)
        {
            _ResultMessage = message;
        }

        public ActionResultEnum ResultType
        {
            get { return ActionResultEnum.Success; }
        }

        public bool ActionSuccessful
        {
            get { return true; }
        }

        public bool ActionCompleted
        {
            get { return true; }
        }

        public string ResultMessage
        {
            get { return _ResultMessage; }
        }
    }

}
