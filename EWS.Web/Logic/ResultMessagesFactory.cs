using Spectrum.SharedKernel.Authorisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EWS.Web.Logic
{
    public class ResultMessagesFactory : IResultMessagesFactory
    {
        public ResultMessagesFactory()
        {

        }

        public IEnumerable<ResultMessage> GetMessages(Exception e)
        {
            List<ResultMessage> result = new List<ResultMessage>();

            if (e is ApplicationException)
                result.Add(new ResultMessage(ResultMessageType.Error, e.Message));
            else if (e is UserNotAuthorisedException)
                result.Add(new ResultMessage(ResultMessageType.Error, "You are attempting to perform an action for which you are not authorised. Please contact a system administrator for assistance."));
            else
                result.Add(new ResultMessage(ResultMessageType.Error, "An unexpected error has occurred."));

            return result;
        }

        public IEnumerable<ResultMessage> GetMessages(ResultMessageType msgType)
        {
            return GetMessages(msgType, "The operation");
        }

        public IEnumerable<ResultMessage> GetMessages(ResultMessageType msgType, string operationDescription)
        {
            string[] messages = { string.Empty };
            messages[0] = (msgType == ResultMessageType.Success) ? 
                operationDescription + " has completed successfully." : messages[0] = operationDescription + " could not be completed.";
            return GetMessages(msgType, messages);
        }

        public IEnumerable<ResultMessage> GetMessages(ResultMessageType msgType, string[] messages)
        {
            foreach (string msg in messages)
            {
                yield return new ResultMessage(msgType, msg);
            }
        }
    }
}