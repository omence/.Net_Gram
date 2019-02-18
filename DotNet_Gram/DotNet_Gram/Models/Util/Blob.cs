using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_Gram.Models.Util
{
    public class Blob
    {   
        //new cloud storage account
        public CloudStorageAccount CloudStorageAccount { get; set; }

        
        public CloudBlobClient CloudBlobClient { get; set; }

        /// <summary>
        /// configures cloud storage account and blob client
        /// </summary>
        /// <param name="configuration"></param>
        public Blob(IConfiguration configuration)
        {
            CloudStorageAccount = CloudStorageAccount.Parse(configuration["BlobConnectionString"]);
            CloudBlobClient = CloudStorageAccount.CreateCloudBlobClient();
        }

        /// <summary>
        /// sets the access to the blob within the container.
        /// </summary>
        /// <param name="containerName"></param>
        /// <returns></returns>
        public async Task<CloudBlobContainer> GetContainer(string containerName)
        {
            CloudBlobContainer cbc = CloudBlobClient.GetContainerReference(containerName);
           await cbc.CreateIfNotExistsAsync();
           await cbc.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            return cbc;
        }

        /// <summary>
        /// gets blob we will use to store image files
        /// </summary>
        /// <param name="imageName"></param>
        /// <param name="containerName"></param>
        /// <returns></returns>
        public async Task<CloudBlob> GetBlob(string imageName, string containerName)
        {
            CloudBlobContainer container = await GetContainer(containerName);
            CloudBlob blob = container.GetBlobReference(imageName);
            return blob;
        }

        /// <summary>
        /// uploads the file to the blob
        /// </summary>
        /// <param name="cloudBlobContainer"></param>
        /// <param name="fileName"></param>
        /// <param name="path"></param>
        public void UploadFile(CloudBlobContainer cloudBlobContainer, string fileName, string path)
        {
            var blobFile = cloudBlobContainer.GetBlockBlobReference(fileName);
            blobFile.UploadFromFileAsync(path);
        }
    }
}
