using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using WorkSphere.Enums;
using WorkSphere.Models;
using WorkSphere.Views;
using Xamarin.Forms;

namespace WorkSphere.ViewModels
{
    public class CoworkerDetailsViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        private Coworker coworker = null;

        public Coworker Coworker
        {
            get { return coworker; }
            set { SetProperty(ref coworker, value); }
        }
        
        public CoworkerDetailsViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            Title = "Coworker";
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters != null && parameters.ContainsKey("coworker"))
            {
                Coworker coworker = parameters["coworker"] as Coworker;
                if (coworker != null)
                {
                    Coworker = coworker;
                }
            }
        }
    }
}
