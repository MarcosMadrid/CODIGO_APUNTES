using Amazon.S3;
using Amazon.S3.Model;
using System.Net;

namespace WebApplicationBucket.Services
{
    public class ServiceStorageS3
    {
        private string BucketName;
        private IAmazonS3 amazonS3;

        public ServiceStorageS3(IConfiguration configuration, IAmazonS3 s3)
        {
            this.amazonS3 = s3;
            BucketName = configuration.GetValue<string>("AWS:BucketName")!;
        }

        public async Task<HttpStatusCode> UploadFile(string fileName, Stream stream)
        {
            PutObjectRequest request = new PutObjectRequest()
            {
                BucketName = BucketName,
                Key = fileName,
                InputStream = stream,
                AutoCloseStream = true,
            };

            var response = await amazonS3.PutObjectAsync(request);
            return response.HttpStatusCode;
        }

        public async Task<HttpStatusCode> DeleteFile(string fileName)
        {
            var response = await amazonS3.DeleteObjectAsync(BucketName, fileName);
            return response.HttpStatusCode;
        }

        public async Task<List<S3Object>> GetFiles()
        {
            ListObjectsResponse listObjects = await amazonS3.ListObjectsAsync(BucketName);
            return
                listObjects.S3Objects;
        }

        public async Task<Stream> StreamAsync(string fileName)
        {
            GetObjectRequest getObject = new GetObjectRequest()
            {
                BucketName = BucketName,
                Key = fileName,
            };
            var response = await amazonS3.GetObjectAsync(getObject);
            Stream stream = response.ResponseStream;
            return stream;
        }
    }
}
