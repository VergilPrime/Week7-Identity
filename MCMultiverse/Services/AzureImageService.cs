//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Azure;
//using Microsoft.WindowsAzure.Storage;
//using Microsoft.WindowsAzure.Storage.Blob;

//namespace MCMultiverse.Services
//{
//    public class AzureImageService : IAzureImageService
//    {
//        private readonly CloudStorageAccount _azureStorageAccount;

//        private readonly CloudBlobClient _azureBlobClient;

//        private readonly CloudBlobContainer _azureBlobContainer;

//        public AzureImageService()
//        {
//            _azureStorageAccount = CloudStorageAccount.Parse(
//                CloudConfigurationManager.GetSetting("AzureConnection"));

//            _azureBlobClient = _azureStorageAccount.CreateCloudBlobClient();

//            _azureBlobContainer = _azureBlobClient.GetContainerReference("mcmultiverse");

//            _azureBlobContainer.CreateIfNotExistsAsync();

//            _azureBlobContainer.SetPermissionsAsync(
//                new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
//        }
//    }
//}
