using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EWS.Web.Logic
{
    public interface IResultMessagesFactory
    {
        IEnumerable<ResultMessage> GetMessages(Exception e);
        IEnumerable<ResultMessage> GetMessages(ResultMessageType msgType);
        IEnumerable<ResultMessage> GetMessages(ResultMessageType msgType, string operationDescription);
        IEnumerable<ResultMessage> GetMessages(ResultMessageType msgType, string[] messages);
    }
}