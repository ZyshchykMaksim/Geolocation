using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Navigation;
using WorkSphere.Enums;
using WorkSphere.Models;

namespace WorkSphere.ViewModels
{
    public class CoworkersViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        public ObservableCollection<GroupCoworker> _coworkers = new ObservableCollection<GroupCoworker>();

        public ObservableCollection<GroupCoworker> CoworkersGroup
        {
            get { return _coworkers; }
            set { SetProperty(ref _coworkers, value); }
        }

        public DelegateCommand<Coworker> SelectedItemCommand { get; private set; }

        public CoworkersViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            SelectedItemCommand = new DelegateCommand<Coworker>(SelectedItem);

            List<Coworker> coworkers = new List<Coworker>()
            {
                new Coworker()
                {
                    SurName = "Baron",
                    LastName = "Alexis",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.Work
                },
                new Coworker()
                {
                    SurName = "Abram",
                    LastName = "Corinne",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.Work
                },
                new Coworker()
                {
                    SurName = "Acosta",
                    LastName = "Tim",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.On_Break
                },
                new Coworker()
                {
                    SurName = "Artega",
                    LastName = "Devid",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.None
                },
                new Coworker()
                {
                    SurName = "Garza",
                    LastName = "Ruby",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.Run_Report
                },
                new Coworker()
                {
                    SurName = "Matthews",
                    LastName = "Patsy",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.Work
                },
                new Coworker()
                {
                    SurName = "Mitchell",
                    LastName = "Dennis",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.On_Break
                },
                new Coworker()
                {
                    SurName = "Frazier",
                    LastName = "Rafael",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.Work
                },
                new Coworker()
                {
                    SurName = "Webb",
                    LastName = "Yvonne",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.None
                },
                new Coworker()
                {
                    SurName = "Ward",
                    LastName = "Paula",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.Work
                },
                new Coworker()
                {
                    SurName = "Rice",
                    LastName = "Chester",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.Run_Report
                },
                //https://randomuser.me/api/portraits/men/51.jpg
                new Coworker()
                {
                    SurName = "Sanchez",
                    LastName = "Theodore",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.Run_Report
                },
            };

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
