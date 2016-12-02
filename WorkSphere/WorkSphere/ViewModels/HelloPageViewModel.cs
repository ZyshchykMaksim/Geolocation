using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;

namespace WorkSphere.ViewModels
{
    public class HelloPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand OnClickCommand { get; set; }
        public HelloPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;

            Title = "Hello";
            OnClickCommand = new DelegateCommand(OnClick);
        }

        private void OnClick()
        {
            _navigationService.NavigateAsync("MainPage");
        }
    }
}
