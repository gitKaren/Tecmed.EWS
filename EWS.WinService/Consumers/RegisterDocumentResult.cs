using Spectrum.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectrum.WinService.Consumers
{
    public class RegisterDocumentResult : IRegisterDocumentResult
    {
        public RegisterDocumentResult(Guid documentId, int documentVersion, string documentReferenceNumber, bool success, string resultMessage)
        {
            this.DocumentId = documentId;
            this.DocumentVersion = documentVersion;
            this.DocumentReferenceNumber = documentReferenceNumber;
            this.Success = success;
            this.ResultMessage = ResultMessage;
        }

        public Guid DocumentId { get; set; }
        public int DocumentVersion { get; set; }
        public string DocumentReferenceNumber { get; set; }
        public bool Success { get; set; }
        public string ResultMessage { get; set; }
    }
}
