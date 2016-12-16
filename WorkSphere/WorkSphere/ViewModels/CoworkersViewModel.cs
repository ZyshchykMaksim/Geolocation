using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Navigation;
using WorkSphere.Enums;
using WorkSphere.Interfaces;
using WorkSphere.Models;
using Xamarin.Forms;

namespace WorkSphere.ViewModels
{
    public class CoworkersViewModel : BaseViewModel
    {
        private string _strSearch;
        private bool _isRefreshing;

        private readonly INavigationService _navigationService;
        private readonly IDataService _dataService;

        private readonly List<Coworker> _allCoworkers;

        private ObservableCollection<GroupCoworker> _coworkers = new ObservableCollection<GroupCoworker>();

        public string StrSearch
        {
            get { return _strSearch; }
            set
            {
                SetProperty(ref _strSearch, value);

                IsBusy = true;
                if (String.IsNullOrWhiteSpace(value))
                    GroupCoworkers(_allCoworkers);
                else
                    SearchCoworkers(value);
                IsBusy = false;
            }
        }


        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetProperty(ref _isRefreshing, value); }
        }

        public ObservableCollection<GroupCoworker> CoworkersGroup
        {
            get { return _coworkers; }
            set { SetProperty(ref _coworkers, value); }
        }


        public DelegateCommand<Coworker> SelectedItemCommand => new DelegateCommand<Coworker>(SelectedItem);

        public DelegateCommand StrSearchCommand => new DelegateCommand(Search, CanSearch);

        public DelegateCommand RefreshCommand => new DelegateCommand(Refresh, CanRefresh);


        public CoworkersViewModel(INavigationService navigationService, IDataService dataService) : base(navigationService)
        {
            _navigationService = navigationService;
            _dataService = dataService;
            _allCoworkers = dataService.GetCoworkers().ToList();

            GroupCoworkers(_allCoworkers);
        }


        private void SearchCoworkers(string strSearch)
        {
            if (!String.IsNullOrEmpty(strSearch))
            {
                List<Coworker> coworkers = _allCoworkers.Where(x => x.FullName.Contains(strSearch, StringComparison.OrdinalIgnoreCase)).ToList();
                GroupCoworkers(coworkers);
            }
        }

        private void GroupCoworkers(List<Coworker> coworkers)
        {
            if (coworkers != null)
            {
                CoworkersGroup.Clear();
                coworkers.Sort((emp1, emp2) => String.Compare(emp1.SurName, emp2.SurName, StringComparison.Ordinal));
                foreach (var item in coworkers)
                {
                    string firstLetter = item.SurName.GetFirstLetter();
                    if (!CoworkersGroup.Any(x => x.FirstInitial.Equals(firstLetter, StringComparison.OrdinalIgnoreCase)))
                    {
                        GroupCoworker group = new GroupCoworker(firstLetter);
                        group.Add(item);

                        CoworkersGroup.Add(group);
                    }
                    else
                    {
                        var group = CoworkersGroup.FirstOrDefault(x => x.FirstInitial.Equals(firstLetter, StringComparison.OrdinalIgnoreCase));
                        if (group != null)
                            group.Add(item);
                    }
                }
            }
        }


        private bool CanSearch() { return true; }

        private void Search() { }

        private bool CanRefresh() { return true; }

        private void Refresh()
        {
            if (String.IsNullOrWhiteSpace(StrSearch))
                GroupCoworkers(_allCoworkers);
            else
                SearchCoworkers(StrSearch);
            IsRefreshing = false;
        }


        private void SelectedItem(Coworker coworker)
        {
            try
            {
                if (coworker == null) return;

                var p = new NavigationParameters();
                p.Add("coworker", coworker);
                _navigationService.NavigateAsync("CoworkerDetails", p, animated: false);
            }
            catch (Exception ex)
            {
            }
        }


        public override void OnNavigatedTo(NavigationParameters parameters)
        {

        }
    }
}
