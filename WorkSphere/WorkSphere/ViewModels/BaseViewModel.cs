using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Prism;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace WorkSphere.ViewModels
{
    public abstract class BaseViewModel : BindableBase, INavigationAware
    {
        private string _title = String.Empty;
        private bool _isBusy = false;

        private INavigationService _navigationService = null;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        protected BaseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {

        }
    }
}
