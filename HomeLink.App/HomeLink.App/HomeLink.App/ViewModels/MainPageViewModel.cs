using HomeLink.App.DataTransfer;
using Plugin.FilePicker;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HomeLink.App.ViewModels {
    public class MainPageViewModel : ViewModelBase {
        private readonly IHomeLinkService _homeLinkService;

        public MainPageViewModel(INavigationService navigationService, IHomeLinkService homeLinkService)
            : base(navigationService) {
            _homeLinkService = homeLinkService;
            _storedFiles     = new ObservableCollection<FileViewModel>();

            UploadCommand    = new DelegateCommand(OnUpload);
            Title            = "Storage";
        }

        private ObservableCollection<FileViewModel> _storedFiles;
        public ObservableCollection<FileViewModel> StoredFiles {
            get => _storedFiles;
            set => SetProperty(ref _storedFiles, value);
        }

        public ICommand UploadCommand { get; }

        private async void OnUpload() {
            var file = await CrossFilePicker.Current.PickFile();
            if (file is null) return; //show error notification

            var fileView = new FileViewModel(file.FileName, file.DataArray);
            _storedFiles.Add(fileView);
            await _homeLinkService.UploadFile(fileView);
        }

        public override async void OnNavigatedTo(INavigationParameters parameters) {
            base.OnNavigatedTo(parameters);

            var files = await _homeLinkService.GetStoredFilesList();
            for (var i = 0; i < files.Length; i++)
                _storedFiles.Add(files[i]);
        }
    }
}
