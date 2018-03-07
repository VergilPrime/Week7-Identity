using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace MCMultiverse.Controllers
{
    public class BlobController : Controller
    {
        private readonly CloudStorageAccount _azureStorageAccount;

        private readonly CloudBlobClient _azureBlobClient;

        private readonly CloudBlobContainer _azureBlobContainer;

        public BlobController()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfigurationRoot configuration = builder.Build();

            _azureStorageAccount = CloudStorageAccount.Parse(
                configuration["ConnectionStrings:AzureConnection"]);

            _azureBlobClient = _azureStorageAccount.CreateCloudBlobClient();

            _azureBlobContainer = _azureBlobClient.GetContainerReference("mcmultiverse");

            _azureBlobContainer.CreateIfNotExistsAsync();

            Task task = _azureBlobContainer.SetPermissionsAsync(
                new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            task.Wait();
        }

        // GET: Blobs
        public ActionResult Index()
        {

            List<string> blobs = new List<string>();
            Task<BlobResultSegment> task = _azureBlobContainer.ListBlobsSegmentedAsync(null);
            task.Wait();
            BlobResultSegment result = task.Result;
            foreach (IListBlobItem item in result.Results)
            {
                if(item.GetType() == typeof(CloudBlockBlob))
                {
                    CloudBlockBlob blob = (CloudBlockBlob)item;
                    blobs.Add(blob.Name);
                }
                else if (item.GetType() == typeof(CloudPageBlob))
                {
                    CloudPageBlob blob = (CloudPageBlob)item;
                    blobs.Add(blob.Name);
                }
                else if (item.GetType() == typeof(CloudBlobDirectory))
                {
                    CloudBlobDirectory blob = (CloudBlobDirectory)item;
                    blobs.Add(blob.Uri.ToString());
                }
            }

            return View(blobs);
        }

        // POST: Blob/Upload
        public IActionResult Upload()
        {
            try
            {
                CloudBlockBlob blob = _azureBlobContainer.GetBlockBlobReference("Blobbathy");

                using (var filestream = System.IO.File.OpenRead(@"kitty.png"))
                {
                    Task task = blob.UploadFromStreamAsync(filestream);

                    task.Wait();
                }

                return RedirectToAction("Index","Blob");
                
            }
            catch
            {
                return View();
            }
        }

        // POST: Blob/Upload
        public IActionResult Display()
        {
            //try
            //{
                CloudBlockBlob blob = _azureBlobContainer.GetBlockBlobReference("Blobbathy");

                //byte[] img = new byte[500000];

                //Task task = blob.DownloadToByteArrayAsync(img, 1);

                blob.DownloadToFileAsync("ReturnKitty.png", new FileMode());

                return RedirectToAction("Index", "Blob");

            //}
            //catch
            //{
            //    return View();
            //}
        }

        // POST: Blob/Delete/5
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                CloudBlockBlob blob = _azureBlobContainer.GetBlockBlobReference("Blobbathy");
                
                Task task = blob.DeleteIfExistsAsync();

                task.Wait();

                return RedirectToAction("Index", "Blob");

            }
            catch
            {
                return View();
            }
        }
    }
}