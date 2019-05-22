using System;
using System.Threading.Tasks;
using HomeLink.App.Extensions;
using HomeLink.App.ViewModels;
using JM.LinqFaster;
using Refit;

namespace HomeLink.App.DataTransfer {
    internal sealed class HomeLinkService : IHomeLinkService {
        private readonly IHomeLinkApi _api;

        public HomeLinkService() => 
            _api = RestService.For<IHomeLinkApi>("https://192.168.0.57:44398");

        public async Task<FileViewModel[]> GetQueuedFilesList() {
            try {
                var queuedFiles = await _api.GetQueuedFilesList().ConfigureAwait(false);
                return queuedFiles.SelectF(f => new FileViewModel(f));
            } catch (ApiException) {
                //TODO: show popup
            } catch (Exception) {
            }
            return Array.Empty<FileViewModel>();
        }

        public async Task<FileViewModel> GetStoredFile(string name) {
            try {
                var storedFileContent = await _api.GetStoredFile(name).ConfigureAwait(false);
                var storedFileBytes   = await storedFileContent.ReadAsByteArrayAsync().ConfigureAwait(false);

                return new FileViewModel(storedFileContent.GetFileName(), storedFileBytes);
            } catch (ApiException) {
                //TODO: show popup
            } catch (Exception) {
            }

            return new FileViewModel(string.Empty);
        }

        public async Task<FileViewModel[]> GetStoredFilesList() {
            try {
                var storedFiles = await _api.GetStoredFilesList().ConfigureAwait(false);
                return storedFiles.SelectF(f => new FileViewModel(f));
            } catch (ApiException) {
                //TODO: show popup
            } catch (Exception) {
            }
            return Array.Empty<FileViewModel>();
        }

        public async Task UploadFile(FileViewModel file) {
            try {
                if (file is null || !file.HasData) throw new ArgumentException(nameof(file));
                await _api.UploadFile(new ByteArrayPart(file.Data, file.Name)).ConfigureAwait(false);
            } catch (ApiException) {
                //TODO: show popup
            } catch (ArgumentException) {
                //TODO: show popup
            } catch (Exception) {
            }
        }
    }
}
