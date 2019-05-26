using Refit;
using System.Collections.Generic;
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

        [Multipart]
        [Post("/api/files")]
        Task UploadFile(IEnumerable<ByteArrayPart> files);
    }
}