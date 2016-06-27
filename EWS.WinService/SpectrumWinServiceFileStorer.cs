using Spectrum.DocumentArchive;
using Spectrum.DocumentArchive.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectrum.WinService
{
    public class SpectrumWinServiceFileStorer : IFileStorer
    {
        ISizeValidator _sizeValidator;
        IExtensionValidator _extensionValidator;

        private string _archiveDirectory = System.Configuration.ConfigurationManager.AppSettings["ArchivePath"];

        public SpectrumWinServiceFileStorer(ISizeValidator sizeValidator, IExtensionValidator extensionValidator)
        {
            if (sizeValidator == null) throw new ArgumentNullException("SizeValidator cannot be null.");
            if (extensionValidator == null) throw new ArgumentNullException("ExtensionValidator cannot be null.");

            _sizeValidator = sizeValidator;
            _extensionValidator = extensionValidator;
        }

        public void StoreFile(Guid documentId, int versionNumber, string fileName)
        {
            if (documentId == null || documentId == Guid.Empty) throw new ArgumentNullException("Document Id may not be null or empty");
            if (versionNumber <= 0) throw new ArgumentOutOfRangeException("Version Number may not be less than 1");
            if (string.IsNullOrEmpty(fileName)) throw new ArgumentOutOfRangeException("File name must be supplied");

            string tempFilePath = this.FilePath;

            if (!File.Exists(tempFilePath)) throw new FileNotFoundException("You are attempting to store a file which does exist in Temp director");
            long size = new System.IO.FileInfo(tempFilePath).Length;
            if (!_sizeValidator.IsDocumentSmallEnough(size)) throw new InvalidOperationException("The file you are attempting to store is too big. Maximum allowed is " + _sizeValidator.GetMaximumSize().ToString() + " bytes");
            if (!_extensionValidator.IsExtensionValid(tempFilePath)) throw new InvalidOperationException("You are attempting to save a file that with an invalid extension.");

            string ext = Path.GetExtension(fileName);

            string dir = Path.Combine(_archiveDirectory, documentId.ToString());

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            string filePathInStore = Path.Combine(dir, versionNumber.ToString() + ext);

            File.Copy(tempFilePath, filePathInStore, true);
        }

        public string FilePath { get; set; }
    }
}
