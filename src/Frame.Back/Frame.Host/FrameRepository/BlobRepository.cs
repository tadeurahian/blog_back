using FrameRepository.Interfaces;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FrameRepository
{
    public class BlobRepository : IBlobRepository
    {
        private readonly StorageCredentials _credenciasStorage;

        public BlobRepository()
        {
            _credenciasStorage = new StorageCredentials("frameworkblob", "lFDeKWUa75qXgYW3YY6s+TUuAdYUw2y87r30mhkmAoNfd0jDSp/tk37OFPpDoGG75ybMI6CzUyAthplnQ2+m2w==");
        }


        public string Adicionar(string dadosBase64, string mimeType, string titulo)
        {            
            CloudStorageAccount conta = new CloudStorageAccount(_credenciasStorage, useHttps: true);
            CloudBlobClient cliente = conta.CreateCloudBlobClient();
            CloudBlobContainer container = cliente.GetContainerReference("imagens");

            container.CreateIfNotExists();

            container.SetPermissions(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });                        

            CloudBlockBlob blob = container.GetBlockBlobReference($"{Guid.NewGuid()}-{titulo}");

            blob.Properties.ContentType = mimeType;

            var bytes = Convert.FromBase64String(dadosBase64.Split(',').Last());

            using (var stream = new MemoryStream(bytes))
            {
                blob.UploadFromStream(stream);
            }

            return blob.Uri.AbsoluteUri;
        }
    }
}
