using Refit;
using System.Net.Http;
using System.Threading.Tasks;

namespace HomeLink.App.DataTransfer {
    public interface IHomeLinkApi {
        [Get("/api/files")]
        Task<string[]> GetStoredFilesList();

        [Get("/api/files/queue")]
        Task<string[]> GetQueuedFilesList();

        [Get("/api/files/{name}")]
        Task<HttpContent> GetStoredFile(string name);

        [Post("/api/files")]
        Task UploadFile(ByteArrayPart file);
    }
}