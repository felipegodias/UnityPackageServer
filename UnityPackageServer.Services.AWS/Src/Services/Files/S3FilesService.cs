using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;

namespace UnityPackageServer.Services.Aws;

public class S3FilesService : IFilesService
{
    private IAmazonS3 _amazonS3;
    private const string _bucket = "verdacciostack-bucket83908e77-wvyeeojo8m2s";
    private const string _prefix = "npm/";

    public S3FilesService()
    {
        _amazonS3 = new AmazonS3Client("AKIAZYOX6XD6DJVXSDAM", "a797I8zGeacB01Y1FDjrMS8v4KRM4EPaoJ7xD+TG");
    }
    
    public async Task WriteAsync(string name, byte[] data)
    {
        var transferUtility = new TransferUtility(_amazonS3);
        using var buffer = new MemoryStream(data);
        var transferUtilityUploadRequest = new TransferUtilityUploadRequest
        {
            BucketName = _bucket,
            Key = MakeKey(name),
            InputStream = buffer
        };
        await transferUtility.UploadAsync(transferUtilityUploadRequest);
    }

    public async Task<byte[]> ReadAsync(string name)
    {
        var transferUtility = new TransferUtility(_amazonS3);
        
        var transferUtilityOpenStreamRequest = new TransferUtilityOpenStreamRequest()
        {
            BucketName = _bucket,
            Key = MakeKey(name),
        };

        try
        {
            Stream steam = await transferUtility.OpenStreamAsync(transferUtilityOpenStreamRequest);
            using var buffer = new MemoryStream();
            await steam.CopyToAsync(buffer);
            return buffer.ToArray();
        }
        catch (AmazonS3Exception)
        {
            return null;
        }
    }

    public async Task<IEnumerable<string>> ListAsync()
    {
        var request = new ListObjectsRequest()
        {
            BucketName = _bucket,
            Prefix = _prefix,
        };

        ListObjectsResponse response = await _amazonS3.ListObjectsAsync(request);
        string[] list = response.S3Objects.Select(o => o.Key.Substring(_prefix.Length)).ToArray();
        return list;
    }

    private string MakeKey(string name)
    {
        return $"{_prefix}{name}";
    }
}