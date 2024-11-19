
using Microsoft.AspNetCore.Http;

namespace e_commerce_backend.Application.Services
{
    public interface IFileService
    {
        Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files);
        Task<string> FileRenameAsync(string fileName);
        Task<bool> CopyFileAsync(string path, IFormFile file);
    }
}
