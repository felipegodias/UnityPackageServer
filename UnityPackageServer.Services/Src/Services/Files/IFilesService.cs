namespace UnityPackageServer.Services;

public interface IFilesService
{
    Task WriteAsync(string name, byte[] data);
    Task<byte[]> ReadAsync(string name);
    Task<IEnumerable<string>> ListAsync();
}