using MassTransit;
using Spectrum.Contracts;
using Spectrum.DocumentArchive;
using Spectrum.DocumentArchive.Repository;
using Spectrum.WinService.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectrum.WinService.Consumers
{
    public class RegisterProductDocumentConsumer : BaseRegisterDocumentConsumer, IConsumer<IRegisterProductDocument>
    {
        public RegisterProductDocumentConsumer(IDocumentRepository repo, IFileStorer fileStorer)
            : base(repo, fileStorer)
        {

        }
        
        public Task Consume(ConsumeContext<IRegisterProductDocument> context)
        {
            bool success = true;
            string resultMessage = string.Empty;
            var msg = context.Message;

            ((SpectrumWinServiceFileStorer)_fileStorer).FilePath = msg.FilePath;

            checkValidity(msg.DocumentId);

            Archive archive = new Archive(_repo);
            
            var refNoBuilder = new ProductDocumentReferenceNumberBuilder(
                msg.DocumentCategoryId, 
                msg.DocumentTypeId, 
                msg.SupplierId, 
                msg.ModalityId, 
                msg.DocumentName);

            List<MetaData> metaDatas = new List<MetaData>();
            foreach (var item in msg.MetaValues)
            {
                metaDatas.Add(new MetaData(item.MetaFieldId, item.MetaValue));
            }

            string fileName = Path.GetFileName(msg.FilePath);

            try
            {
                archive.CreateDocument(
                    msg.DocumentId,
                    msg.Expiry,
                    refNoBuilder.GetReferenceNumber(),
                    msg.DocumentCategoryId,
                    DocumentTypeCategoryScopes.Product,
                    msg.DocumentTypeId,
                    msg.DocumentName,
                    msg.RelatedReferenceNumber,
                    _fileStorer,
                    fileName,
                    msg.FileSize,
                    msg.UserName,
                    metaDatas.ToArray(),
                    msg.AllowedRoles);
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

            context.Respond(new RegisterDocumentResult(msg.DocumentId, 1, refNoBuilder.GetReferenceNumber(), success, resultMessage));
            return Task.FromResult(0);
        }
    }

    public class RegisterNonProductDocumentConsumer : BaseRegisterDocumentConsumer, IConsumer<IRegisterNonProductDocument>
    {
        public RegisterNonProductDocumentConsumer(IDocumentRepository repo, IFileStorer fileStorer)
            : base(repo, fileStorer)
        {

        }

        public Task Consume(ConsumeContext<IRegisterNonProductDocument> context)
        {
            var msg = context.Message;

            ((SpectrumWinServiceFileStorer)_fileStorer).FilePath = msg.FilePath;

            checkValidity(msg.DocumentId);

            Archive archive = new Archive(_repo);

            var refNoBuilder = new NonProductDocumentReferenceNumberBuilder(
                msg.DocumentCategoryId,
                msg.DocumentTypeId,
                msg.DocumentName);

            List<MetaData> metaDatas = new List<MetaData>();
            foreach (var item in msg.MetaValues)
            {
                metaDatas.Add(new MetaData(item.MetaFieldId, item.MetaValue));
            }

            string fileName = Path.GetFileName(msg.FilePath);

            archive.CreateDocument(
                msg.DocumentId,
                msg.Expiry,
                refNoBuilder.GetReferenceNumber(),
                msg.DocumentCategoryId,
                DocumentTypeCategoryScopes.NonProduct,
                msg.DocumentTypeId,
                msg.DocumentName,
                msg.RelatedReferenceNumber,
                _fileStorer,
                fileName,
                msg.FileSize,
                msg.UserName,
                metaDatas.ToArray(),
                msg.AllowedRoles);

            return Task.FromResult(0);
        }
    }
}
