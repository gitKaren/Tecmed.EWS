namespace EWS.Domain.ActionResults
{
    public class NoneResult : IActionResult
    {

        private string _ResultMessage = "Nothing done";

        public NoneResult()
        {

        }

        public void SetResultMessage(string message)
        {
            _ResultMessage = message;
        }

        public ActionResultEnum ResultType
        {
            get { return ActionResultEnum.None; }
        }

        public bool ActionSuccessful
        {
            get { return false; }
        }

        public bool ActionCompleted
        {
            get { return false; }
        }

        public string ResultMessage
        {
            get { return _ResultMessage; }
        }
    }

}
