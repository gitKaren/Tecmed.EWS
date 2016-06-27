using MassTransit;
using Spectrum.Contracts;
using Spectrum.DocumentArchive;
using Spectrum.DocumentArchive.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectrum.WinService.Consumers
{
    public class BaseRegisterDocumentConsumer
    {
        protected IDocumentRepository _repo;
        protected IFileStorer _fileStorer;

        public BaseRegisterDocumentConsumer(IDocumentRepository repo, IFileStorer fileStorer)
        {
            if (repo == null) throw new ArgumentNullException("Document Repository may not be null");
            if (fileStorer == null) throw new ArgumentException("FileStorer may not be null");
            _repo = repo;
            _fileStorer = fileStorer;
        }

        protected void checkValidity(Guid documentId)
        {
            if (documentId == null || documentId == Guid.Empty) throw new ArgumentNullException("Invalid documentId. Document Id may not be null or empty");
        }
    }
}
