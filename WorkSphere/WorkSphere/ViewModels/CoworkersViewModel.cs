using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Navigation;
using WorkSphere.Enums;
using WorkSphere.Models;
using Xamarin.Forms;

namespace WorkSphere.ViewModels
{
    public class CoworkersViewModel : BaseViewModel
    {
        private string _strSearch;

        private readonly INavigationService _navigationService;
        private readonly List<Coworker> _allCoworkers;

        private ObservableCollection<GroupCoworker> _coworkers = new ObservableCollection<GroupCoworker>();

        public string StrSearch
        {
            get { return _strSearch; }
            set
            {
                SetProperty(ref _strSearch, value);

                if (String.IsNullOrWhiteSpace(value))
                    GroupCoworkers(_allCoworkers);
                else
                    SearchCoworkers();
            }
        }

        public ObservableCollection<GroupCoworker> CoworkersGroup
        {
            get { return _coworkers; }
            set { SetProperty(ref _coworkers, value); }
        }

        public DelegateCommand<Coworker> SelectedItemCommand => new DelegateCommand<Coworker>(SelectedItem);

        public DelegateCommand StrSearchCommand => new DelegateCommand(Search, CanSearch);


        public CoworkersViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;

            _allCoworkers = new List<Coworker>()
            {
                new Coworker()
                {
                    SurName = "Baron",
                    LastName = "Alexis",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.Work,
                    Image = ImageSource.FromResource("WorkSphere.Images.Users.32.jpg")
                },
                new Coworker()
                {
                    SurName = "Abram",
                    LastName = "Corinne",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.Work,
                    Image = ImageSource.FromResource("WorkSphere.Images.Users.65.jpg")
                },
                new Coworker()
                {
                    SurName = "Acosta",
                    LastName = "Tim",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.On_Break,
                    Image = ImageSource.FromResource("WorkSphere.Images.Users.35.jpg")
                },
                new Coworker()
                {
                    SurName = "Artega",
                    LastName = "Devid",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.None,
                    Image = ImageSource.FromResource("WorkSphere.Images.Users.62.jpg")
                },
                new Coworker()
                {
                    SurName = "Garza",
                    LastName = "Ruby",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.Run_Report,
                    Image = ImageSource.FromResource("WorkSphere.Images.Users.2.jpg")
                },
                new Coworker()
                {
                    SurName = "Matthews",
                    LastName = "Patsy",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.Work,
                    Image = ImageSource.FromResource("WorkSphere.Images.Users.47.jpg")
                },
                new Coworker()
                {
                    SurName = "Mitchell",
                    LastName = "Dennis",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.On_Break,
                    Image = ImageSource.FromResource("WorkSphere.Images.Users.88.jpg")
                },
                new Coworker()
                {
                    SurName = "Frazier",
                    LastName = "Rafael",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.Work,
                    Image = ImageSource.FromResource("WorkSphere.Images.Users.94.jpg")
                },
                new Coworker()
                {
                    SurName = "Webb",
                    LastName = "Yvonne",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.None,
                    Image = ImageSource.FromResource("WorkSphere.Images.Users.96.jpg")
                },
                new Coworker()
                {
                    SurName = "Ward",
                    LastName = "Paula",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.Work,
                    Image = ImageSource.FromResource("WorkSphere.Images.Users.3.jpg")
                },
                new Coworker()
                {
                    SurName = "Rice",
                    LastName = "Chester",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.Run_Report,
                    Image = ImageSource.FromResource("WorkSphere.Images.Users.71.jpg")
                },
                new Coworker()
                {
                    SurName = "Sanchez",
                    LastName = "Theodore",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.Run_Report,
                    Image = ImageSource.FromResource("WorkSphere.Images.Users.51.jpg")
                },
            };

            GroupCoworkers(_allCoworkers);
        }


        private void SearchCoworkers()
        {
            List<Coworker> coworkers = _allCoworkers.Where(x => x.FullName.Contains(StrSearch, StringComparison.OrdinalIgnoreCase)).ToList();
            GroupCoworkers(coworkers);
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
                        var group =
                            CoworkersGroup.FirstOrDefault(
                                x => x.FirstInitial.Equals(firstLetter, StringComparison.OrdinalIgnoreCase));
                        if (group != null)
                            group.Add(item);
                    }
                }
            }
        }


        private bool CanSearch()
        {
            return true;
        }

        private void Search()
        {
            //SearchCoworkers();
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
