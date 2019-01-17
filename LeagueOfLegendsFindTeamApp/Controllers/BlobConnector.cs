using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LeagueOfLegendsFindTeamApp.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace LeagueOfLegendsFindTeamApp.Controllers
{
    public class BlobConnector
    {
        private static readonly CloudBlobContainer IconsContainer;
        private static CloudBlobContainer ProjectImages;

        static BlobConnector()
        {
            //TODO: Nie ustawia automatycznie uprawnień na kontenerach na publiczne, przez co nie będzie mozna pobrać obrazka. Trzeba robić to ręcznie przy tworzeniu kontenera.
            var storageCredentials = new StorageCredentials("damiandziuraportfolio", "eL6FmFEJ8sp+zC3NRIfFY8rBg4cS1ySypJs8b+52p7OJv2si1+YiaARwZyp6GOzvrPH3EC89Op8rU4gYbB47+w==");
            var cloudStorageAccount = new CloudStorageAccount(storageCredentials, true);
            var cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();

            IconsContainer = cloudBlobClient.GetContainerReference("icons");
            IconsContainer.CreateIfNotExistsAsync();

            ProjectImages = cloudBlobClient.GetContainerReference("projectimages");
            ProjectImages.CreateIfNotExistsAsync();
        }

        public static bool RemoveIcon(Image image)
        {
            CloudBlockBlob cBlob = IconsContainer.GetBlockBlobReference(image.Guid + image.FileName);

            return cBlob.DeleteIfExists();

        }
        public static void UploadIcon(HttpPostedFileBase file, Image image)
        {
            CloudBlockBlob cBlob = IconsContainer.GetBlockBlobReference(image.Guid + image.FileName);
            cBlob.Properties.ContentType = file.ContentType;


            cBlob.UploadFromStream(file.InputStream);
        }

        public static bool RemoveScreenshot(Image image)
        {
            CloudBlockBlob cBlob = ProjectImages.GetBlockBlobReference(image.Guid + image.FileName);

            return cBlob.DeleteIfExists();

        }
        public static void UploadScreenshot(HttpPostedFileBase file, Image image)
        {
            CloudBlockBlob cBlob = ProjectImages.GetBlockBlobReference(image.Guid + image.FileName);
            cBlob.Properties.ContentType = file.ContentType;


            cBlob.UploadFromStream(file.InputStream);
        }
    }
}