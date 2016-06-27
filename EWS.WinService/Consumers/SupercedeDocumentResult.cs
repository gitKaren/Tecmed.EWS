using Spectrum.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectrum.WinService.Consumers
{
    public class SupercedeDocumentResult : ISupercedeDocumentResult
    {
        public SupercedeDocumentResult(Guid documentId, bool success, string resultMessage)
        {
            this.DocumentId = documentId;
            this.Success = success;
            this.ResultMessage = ResultMessage;
        }

        public Guid DocumentId { get; set; }
        public bool Success { get; set; }
        public string ResultMessage { get; set; }
    }
}
