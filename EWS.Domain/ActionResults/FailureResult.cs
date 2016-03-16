using System.Collections.Generic;
namespace EWS.Domain.ActionResults
{
    public class FailureResult : IActionResult
    {

        private string _ResultMessage;

        public FailureResult(string resultMessage)
        {
            _ResultMessage = resultMessage;
        }

        public FailureResult(List<string> failureReasons)
        {
            string prefix = string.Empty;
            _ResultMessage = string.Empty;
            foreach (string s in failureReasons)
            {
                _ResultMessage = string.Concat(prefix, string.Concat(_ResultMessage, s));
                prefix = ", ";
            }
        }

        public void SetResultMessage(string message)
        {
            _ResultMessage = message;
        }

        public ActionResultEnum ResultType
        {
            get { return ActionResultEnum.Failure; }
        }

        public bool ActionSuccessful
        {
            get { return false; }
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
