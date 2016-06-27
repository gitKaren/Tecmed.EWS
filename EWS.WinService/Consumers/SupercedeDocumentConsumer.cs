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
    public class SupercedeDocumentConsumer : IConsumer<ISupercedeDocument>
    {
        private IDocumentRepository _repo;
        private IFileStorer _fileStorer;

        public SupercedeDocumentConsumer(IDocumentRepository repo, IFileStorer fileStorer)
        {
            if (repo == null) throw new ArgumentNullException("Document Repository may not be null");
            if (fileStorer == null) throw new ArgumentException("FileStorer may not be null");
            _repo = repo;
            _fileStorer = fileStorer;
        }

        public Task Consume(ConsumeContext<ISupercedeDocument> context)
        {
            bool success = true;
            string resultMessage = string.Empty;
            var msg = context.Message;

            ((SpectrumWinServiceFileStorer)_fileStorer).FilePath = msg.FilePath;

            checkValidity(msg.DocumentId);

            Archive archive = new Archive(_repo);
            string fileName = Path.GetFileName(msg.FilePath);
            try
            {
                archive.SupercedeDocument(
                    msg.DocumentId,
                    msg.Expiry,
                    _fileStorer,
                    fileName,
                    msg.FileSize,
                    msg.UserName);
            }
            catch (FileNotFoundException)
            {
                resultMessage = "Filepath is not found: " + msg.FilePath;
                success = false;
            }
            catch (Exception ex)
            {
                resultMessage = ex.Message;
                success = false;
            }

            context.Respond(new SupercedeDocumentResult(msg.DocumentId, success, resultMessage));
            return Task.FromResult(0);
        }

        protected void checkValidity(Guid documentId)
        {
            if (documentId == null || documentId == Guid.Empty) throw new ArgumentNullException("Invalid documentId. Document Id may not be null or empty");
        }
    }
}
