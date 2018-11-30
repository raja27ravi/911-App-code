//using Google.Apis.Storage.v1;
//using Google.Apis.Storage.v1.Data;
//using Google.Cloud.Storage.V1;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Net.Http;
//using System.Security.Cryptography;
//using System.Text;

//namespace GoogleCloudSamples
//{
//    public class Storage
//    {
//        private static readonly string s_projectId = "YOUR-PROJECT-ID";

//        private static readonly string s_usage =
//            "Usage: \n" +
//            "  Storage create [new-bucket-name]\n" +
//            "  Storage create-regional-bucket location [new-bucket-name]\n" +
//            "  Storage list\n" +
//            "  Storage list bucket-name [prefix] [delimiter]\n" +
//            "  Storage get-metadata bucket-name object-name\n" +
//            "  Storage get-bucket-metadata bucket-name\n" +
//            "  Storage make-public bucket-name object-name\n" +
//            "  Storage upload [-key encryption-key] bucket-name local-file-path [object-name]\n" +
//            "  Storage copy source-bucket-name source-object-name dest-bucket-name dest-object-name\n" +
//            "  Storage move bucket-name source-object-name dest-object-name\n" +
//            "  Storage download [-key encryption-key] bucket-name object-name [local-file-path]\n" +
//            "  Storage download-byte-range bucket-name object-name range-begin range-end [local-file-path]\n" +
//            "  Storage generate-signed-url bucket-name object-name\n" +
//            "  Storage view-bucket-iam-members bucket-name\n" +
//            "  Storage add-bucket-iam-member bucket-name member\n" +
//            "  Storage remove-bucket-iam-member bucket-name role member\n" +
//            "  Storage add-bucket-default-kms-key bucket-name key-location key-ring key-name\n" +
//            "  Storage upload-with-kms-key bucket-name key-location\n" +
//            "                              key-ring key-name local-file-path [object-name]\n" +
//            "  Storage print-acl bucket-name\n" +
//            "  Storage print-acl bucket-name object-name\n" +
//            "  Storage add-owner bucket-name user-email\n" +
//            "  Storage add-owner bucket-name object-name user-email\n" +
//            "  Storage add-default-owner bucket-name user-email\n" +
//            "  Storage remove-owner bucket-name user-email\n" +
//            "  Storage remove-owner bucket-name object-name user-email\n" +
//            "  Storage remove-default-owner bucket-name user-email\n" +
//            "  Storage delete bucket-name\n" +
//            "  Storage delete bucket-name object-name [object-name]\n" +
//            "  Storage enable-requester-pays bucket-name\n" +
//            "  Storage disable-requester-pays bucket-name\n" +
//            "  Storage get-requester-pays bucket-name\n" +
//            "  Storage generate-encryption-key\n" +
//            "  Storage get-bucket-default-event-based-hold bucket-name\n" +
//            "  Storage enable-bucket-default-event-based-hold bucket-name\n" +
//            "  Storage disable-bucket-default-event-based-hold bucket-name\n" +
//            "  Storage lock-bucket-retention-policy bucket-name\n" +
//            "  Storage set-bucket-retention-policy bucket-name retention-period\n" +
//            "  Storage remove-bucket-retention-policy bucket-name\n" +
//            "  Storage get-bucket-retention-policy bucket-name\n" +
//            "  Storage set-object-temporary-hold bucket-name object-name\n" +
//            "  Storage release-object-temporary-hold bucket-name object-name\n" +
//            "  Storage set-object-event-based-hold bucket-name object-name\n" +
//            "  Storage release-object-event-based-hold bucket-name object-name\n";

//        // [START storage_create_bucket]
//        private void CreateBucket(string bucketName)
//        {
//            var storage = StorageClient.Create();
//            storage.CreateBucket(s_projectId, bucketName);
//            Console.WriteLine($"Created {bucketName}.");
//        }
//        // [END storage_create_bucket]

//        private void CreateRegionalBucket(string location, string bucketName)
//        {
//            var storage = StorageClient.Create();
//            Bucket bucket = new Bucket { Location = location, Name = bucketName };
//            storage.CreateBucket(s_projectId, bucket);
//            Console.WriteLine($"Created {bucketName}.");
//        }

//        // [START storage_list_buckets]
//        private void ListBuckets()
//        {
//            var storage = StorageClient.Create();
//            foreach (var bucket in storage.ListBuckets(s_projectId))
//            {
//                Console.WriteLine(bucket.Name);
//            }
//        }
//        // [END storage_list_buckets]

//        // [START storage_delete_bucket]
//        private void DeleteBucket(string bucketName)
//        {
//            var storage = StorageClient.Create();
//            storage.DeleteBucket(bucketName);
//            Console.WriteLine($"Deleted {bucketName}.");
//        }
//        // [END storage_delete_bucket]

//        // [START storage_list_files]
//        private void ListObjects(string bucketName)
//        {
//            var storage = StorageClient.Create();
//            foreach (var storageObject in storage.ListObjects(bucketName, ""))
//            {
//                Console.WriteLine(storageObject.Name);
//            }
//        }
//        // [END storage_list_files]

//        // [START storage_list_files_with_prefix]
//        private void ListObjects(string bucketName, string prefix,
//            string delimiter)
//        {
//            var storage = StorageClient.Create();
//            var options = new ListObjectsOptions() { Delimiter = delimiter };
//            foreach (var storageObject in storage.ListObjects(
//                bucketName, prefix, options))
//            {
//                Console.WriteLine(storageObject.Name);
//            }
//        }
//        // [END storage_list_files_with_prefix]

//        // [START storage_upload_file]
//        private void UploadFile(string bucketName, string localPath,
//            string objectName = null)
//        {
//            var storage = StorageClient.Create();
//            using (var f = File.OpenRead(localPath))
//            {
//                objectName = objectName ?? Path.GetFileName(localPath);
//                storage.UploadObject(bucketName, objectName, null, f);
//                Console.WriteLine($"Uploaded {objectName}.");
//            }
//        }
//        // [END storage_upload_file]

//        // [START storage_upload_encrypted_file]
//        private void UploadEncryptedFile(string key, string bucketName,
//            string localPath, string objectName = null)
//        {
//            var storage = StorageClient.Create();
//            using (var f = File.OpenRead(localPath))
//            {
//                objectName = objectName ?? Path.GetFileName(localPath);
//                storage.UploadObject(bucketName, objectName, null, f,
//                    new UploadObjectOptions()
//                    {
//                        EncryptionKey = EncryptionKey.Create(
//                        Convert.FromBase64String(key))
//                    });
//                Console.WriteLine($"Uploaded {objectName}.");
//            }
//        }
//        // [END storage_upload_encrypted_file]

//        // [START storage_delete_file]
//        private void DeleteObject(string bucketName, IEnumerable<string> objectNames)
//        {
//            var storage = StorageClient.Create();
//            foreach (string objectName in objectNames)
//            {
//                storage.DeleteObject(bucketName, objectName);
//                Console.WriteLine($"Deleted {objectName}.");
//            }
//        }
//        // [END storage_delete_file]

//        // [START storage_download_file]
//        private void DownloadObject(string bucketName, string objectName,
//            string localPath = null)
//        {
//            var storage = StorageClient.Create();
//            localPath = localPath ?? Path.GetFileName(objectName);
//            using (var outputFile = File.OpenWrite(localPath))
//            {
//                storage.DownloadObject(bucketName, objectName, outputFile);
//            }
//            Console.WriteLine($"downloaded {objectName} to {localPath}.");
//        }
//        // [END storage_download_file]


//    }