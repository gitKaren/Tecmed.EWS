using Spectrum.DocumentArchive.Repository;
using Spectrum.WinService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Spectrum.WinService
{
    public class SpectrumWinServiceDocumentRepository : IDocumentRepository
    {
        public void PersistDocument(DocumentArchive.Document document)
        {
            Entities ent = new Entities();
            Document dbDoc = ent.Documents
                .Include(x => x.DocumentVersions)
                .Include(x => x.DocumentVersions.Select(x1 => x1.DocumentVersionExpiries))
                .Include(x => x.Roles)
                .Include(x => x.DocumentMetaValues)
                .SingleOrDefault(p => p.ID == document.Id);

            if (dbDoc == null)
            {
                //Create Document
                dbDoc = createDocument(document, dbDoc);
                ent.Documents.Add(dbDoc);
            }
            else
            {
                //Update Document
                updateDocument(document, dbDoc);
            }

            foreach (DocumentArchive.Version version in document.GetVersionHistory().OrderBy(p => p.Number))
            {
                DocumentVersion dbVersion = dbDoc.DocumentVersions.SingleOrDefault(p => p.VersionNumber == version.Number);
                if (dbVersion == null)
                {
                    //Create Version
                    dbVersion = createVersion(document, version, dbVersion);
                    ent.DocumentVersions.Add(dbVersion);

                    DocumentVersionExpiry dbExp = createVersionExpiry(document, version);
                    dbVersion.DocumentVersionExpiries.Add(dbExp);
                }
                else
                {
                    //Check if Expiry Date changed
                    DocumentVersionExpiry dbCurrentExpiry = dbVersion.DocumentVersionExpiries.OrderByDescending(p => p.ExpiryDate).First();
                    if (version.ExpiryDate != dbCurrentExpiry.ExpiryDate)
                    {
                        DocumentVersionExpiry dbExp = createVersionExpiry(document, version);
                        dbVersion.DocumentVersionExpiries.Add(dbExp);
                    }
                }
            }

            updateMetaValues(document, dbDoc);
            updateRoles(ent, document, dbDoc);
            ent.SaveChanges();
        }

        public DocumentArchive.Document RetrieveDocument(Guid id)
        {
            Entities ent = new Entities();
            Document dbDoc = ent.Documents
                .Include(x => x.DocumentType)
                .Include(x => x.DocumentType.DocumentTypeCategory)
                .Include(x => x.DocumentVersions)
                .Include(x => x.DocumentVersions.Select(x1 => x1.DocumentVersionExpiries))
                .Include(x => x.Roles)
                .Include(x => x.DocumentMetaValues)
                .Include(x => x.DocumentMetaValues.Select(x1 => x1.DocumentMetaField))
                .SingleOrDefault(p => p.ID == id);

            List<DocumentArchive.Version> versions = new List<DocumentArchive.Version>();

            foreach (var dbVersion in dbDoc.DocumentVersions)
            {
                List<DocumentArchive.VersionExpiryInfo> versionExpiries = new List<DocumentArchive.VersionExpiryInfo>();

                foreach (var dbVersionExpiry in dbVersion.DocumentVersionExpiries)
                {
                    versionExpiries.Add(new DocumentArchive.VersionExpiryInfo(dbVersionExpiry.ExpiryDate, dbVersionExpiry.ModifyingUser));
                }

                var version = new DocumentArchive.Version(dbVersion.VersionNumber, dbVersion.FileName, dbVersion.VersionDate, dbVersion.VersionCreator, dbVersion.FileSize, versionExpiries);
                versions.Add(version);
            }

            List<DocumentArchive.MetaDataDisplay> metaDatas = new List<DocumentArchive.MetaDataDisplay>();
            foreach (var dbMetaValue in dbDoc.DocumentMetaValues)
            {
                metaDatas.Add(new DocumentArchive.MetaDataDisplay(dbMetaValue.documentMetaFieldID, dbMetaValue.DocumentMetaField.MetaFieldName, dbMetaValue.MetaValue));
            }

            string[] roles = dbDoc.Roles.Select(p => p.RoleName).ToArray();

            return Spectrum.DocumentArchive.DocumentFactory.BuildDocument(
                dbDoc.ID,
                dbDoc.documentTypeID,
                dbDoc.DocumentType.documentTypeCategoryID,
                dbDoc.DocumentName,
                dbDoc.RefNo,
                dbDoc.TargetRef,
                dbDoc.CreatedDate,
                (Spectrum.DocumentArchive.DocumentTypeCategoryScopes)dbDoc.DocumentType.DocumentTypeCategory.Scope,
                versions,
                metaDatas,
                roles);
        }

        public void DeleteDocument(DocumentArchive.Document document)
        {
            Entities ent = new Entities();
            Document dbDoc = ent.Documents.Find(document.Id);
            dbDoc.Deleted = true;
            ent.SaveChanges();
        }

        public bool DocumentExists(Guid id)
        {
            Entities ent = new Entities();
            return ent.Documents.Any(p => p.ID == id);
        }

        public IEnumerable<DocumentArchive.MetaDataDisplay> GetAllMetaDataDisplay()
        {
            Entities ent = new Entities();
            var metaFields = ent.DocumentMetaFields;
            foreach (var item in metaFields)
            {
                yield return new DocumentArchive.MetaDataDisplay(item.ID, item.MetaFieldName, string.Empty);
            }
        }

        #region Helpers

        private static void updateRoles(Entities ent, DocumentArchive.Document document, Document dbDoc)
        {
            var intersectingRoleNames = dbDoc.Roles.Select(p => p.RoleName).Intersect(document.GetRoles());
            var insertions = document.GetRoles().Where(p => !intersectingRoleNames.Contains(p));
            var removals = dbDoc.Roles.Where(p => !intersectingRoleNames.Contains(p.RoleName)).Select(p => p.RoleName);
            var allRoles = ent.Roles;

            //Yes yes, this code is ridiculous, but I'm tired
            foreach (string role in insertions)
            {
                dbDoc.Roles.Add(allRoles.Single(p => p.RoleName == role));
            }

            foreach (string role in removals)
            {
                dbDoc.Roles.Remove(allRoles.Single(p => p.RoleName == role));
            }
        }

        private static void updateMetaValues(DocumentArchive.Document document, Document dbDoc)
        {
            dbDoc.DocumentMetaValues.Clear();

            foreach (var mv in document.GetMetaData())
            {
                dbDoc.DocumentMetaValues.Add(new DocumentMetaValue()
                {
                    documentID = document.Id,
                    documentMetaFieldID = mv.MetaFieldId,
                    MetaValue = mv.MetaValue
                });
            }
        }

        private static DocumentVersionExpiry createVersionExpiry(DocumentArchive.Document document, DocumentArchive.Version version)
        {
            DocumentVersionExpiry dbExp = new DocumentVersionExpiry()
            {
                VersionNumber = version.Number,
                documentId = document.Id,
                ExpiryDate = version.ExpiryDate,
                ModifyingUser = version.User
            };
            return dbExp;
        }

        private static DocumentVersion createVersion(DocumentArchive.Document document, DocumentArchive.Version version, DocumentVersion dbVersion)
        {
            dbVersion = new DocumentVersion()
            {
                documentID = document.Id,
                FileName = version.FileName,
                FileSize = version.FileSize,
                VersionCreator = version.User,
                VersionDate = version.VersionDate,
                VersionNumber = version.Number
            };
            return dbVersion;
        }

        private static void updateDocument(DocumentArchive.Document document, Document dbDoc)
        {
            dbDoc.Active = true;
            dbDoc.CreatedDate = document.CreatedDate;
            dbDoc.documentTypeID = document.DocumentTypeId;
            dbDoc.LatestFileName = document.GetLatestVersion().FileName;
            dbDoc.LatestSize = document.GetLatestVersion().FileSize;
            dbDoc.LatestVersionCreator = document.GetLatestVersion().User;
            dbDoc.LatestVersionDate = document.GetLatestVersion().VersionDate;
            dbDoc.LatestVersionNumber = document.GetLatestVersion().Number;
            dbDoc.DocumentName = document.DocumentName;
            dbDoc.RefNo = document.ReferenceNumber;
            dbDoc.TargetRef = document.TargetReference;
        }

        private static Document createDocument(DocumentArchive.Document document, Document dbDoc)
        {
            dbDoc = new Document()
            {
                ID = document.Id,
                Active = true,
                CreatedDate = document.CreatedDate,
                documentTypeID = document.DocumentTypeId,
                LatestFileName = document.GetLatestVersion().FileName,
                LatestSize = document.GetLatestVersion().FileSize,
                LatestVersionCreator = document.GetLatestVersion().User,
                LatestVersionDate = document.GetLatestVersion().VersionDate,
                LatestVersionNumber = document.GetLatestVersion().Number,
                DocumentName = document.DocumentName,
                RefNo = document.ReferenceNumber,
                TargetRef = document.TargetReference
            };
            return dbDoc;
        }

        #endregion
    }
}
