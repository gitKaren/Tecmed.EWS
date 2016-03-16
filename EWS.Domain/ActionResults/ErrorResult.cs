using System;
using System.Collections.Generic;
namespace EWS.Domain.ActionResults
{
    public class ErrorResult : IActionResult
    {

        private string _ResultMessage;

        public ErrorResult(Exception ex)
        {
            _ResultMessage = ex.Message;
        }

        public ErrorResult(string errorMessage)
        {
            _ResultMessage = errorMessage;
        }

        public void SetResultMessage(string message)
        {
            _ResultMessage = message;
        }

        public ActionResultEnum ResultType 
        {
            get { return ActionResultEnum.SystemError; }
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
