using Microsoft.Practices.Unity;
using Prism.Unity;
using WorkSphere.Interfaces;
using WorkSphere.Services;
using WorkSphere.Views;

namespace WorkSphere
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync("Coworkers");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<Tabbed>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<Coworkers>();
            Container.RegisterTypeForNavigation<CoworkerDetails>();

            Container.RegisterType<IDataService, DataService>();
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }
    }
}
