using System;
using System.Web;
using LeagueOfLegendsFindTeamApp.Models.DatabaseModels;
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
            CloudBlockBlob cBlob = IconsContainer.GetBlockBlobReference(Guid.NewGuid().ToString() + image.FileName);

            return cBlob.DeleteIfExists();

        }
        public static void UploadIcon(HttpPostedFileBase file, Image image)
        {
            CloudBlockBlob cBlob = IconsContainer.GetBlockBlobReference(Guid.NewGuid().ToString() + image.FileName);
            cBlob.Properties.ContentType = file.ContentType;


            cBlob.UploadFromStream(file.InputStream);
        }

        public static bool RemoveScreenshot(Image image)
        {
            CloudBlockBlob cBlob = ProjectImages.GetBlockBlobReference(Guid.NewGuid().ToString() + image.FileName);

            return cBlob.DeleteIfExists();

        }
        public static void UploadScreenshot(HttpPostedFileBase file, Image image)
        {
            CloudBlockBlob cBlob = ProjectImages.GetBlockBlobReference(Guid.NewGuid().ToString() + image.FileName);
            cBlob.Properties.ContentType = file.ContentType;
            //TODO: Nie bedzie to dzialac, nie zwraca w zaden sposob linku i nie jestem w stanie wygenerowac linku dlatego ze guid jest generowany dopiero tutaj - do poprawy

            cBlob.UploadFromStream(file.InputStream);
        }
    }
}