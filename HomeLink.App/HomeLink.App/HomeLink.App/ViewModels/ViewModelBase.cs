﻿using Prism.Mvvm;
using Prism.Navigation;

namespace HomeLink.App.ViewModels {
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible {
        protected INavigationService NavigationService { get; private set; }

        private string _title = string.Empty;
        public string Title {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public ViewModelBase(INavigationService navigationService) => NavigationService = navigationService;

        public virtual void OnNavigatedFrom(INavigationParameters parameters) {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters) {
        }

        public virtual void OnNavigatingTo(INavigationParameters parameters) {
        }

        public virtual void Destroy() {
        }
    }
}
