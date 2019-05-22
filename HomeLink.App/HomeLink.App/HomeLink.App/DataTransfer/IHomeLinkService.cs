using HomeLink.App.ViewModels;
using System.Threading.Tasks;

namespace HomeLink.App.DataTransfer {
    public interface IHomeLinkService {
        Task<FileViewModel[]> GetStoredFilesList();

        Task<FileViewModel[]> GetQueuedFilesList();

        Task<FileViewModel> GetStoredFile(string name);

        Task UploadFile(FileViewModel file);
    }
}
