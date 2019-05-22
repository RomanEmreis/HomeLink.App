using Prism.Mvvm;
using System.IO;

namespace HomeLink.App.ViewModels {
    public sealed class FileViewModel : BindableBase {
        private string _name;
        private byte[] _data;

        public FileViewModel(string name) {
            _name = Path.GetFileName(name);
            _data = new byte[0];
        }

        public FileViewModel(string name, byte[] data) {
            _name = Path.GetFileName(name);
            _data = data;
        }

        public string Name {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public byte[] Data => _data;

        public bool HasData => _data.Length != 0;
    }
}