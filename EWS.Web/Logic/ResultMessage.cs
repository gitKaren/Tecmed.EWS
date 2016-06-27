using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EWS.Web.Logic
{
    public enum ResultMessageType
    {
        Success,
        Error
    }

    public class ResultMessage
    {
        public ResultMessage(ResultMessageType messageType, string message)
        {
            this.MessageType = messageType;
            this.Message = message;
        }

        public ResultMessageType MessageType { get; private set; }
        public string Message { get; private set; }
    }
}