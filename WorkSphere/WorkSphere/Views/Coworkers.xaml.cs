using Xamarin.Forms;

namespace WorkSphere.Views
{
    public partial class Coworkers : ContentPage
    {
        public Coworkers()
        {
            InitializeComponent();
            CoworkersListView.ItemSelected += delegate (object sender, SelectedItemChangedEventArgs args)
            {
                if (args.SelectedItem == null)
                    return;

                ((ListView)sender).SelectedItem = null;
            };
        }
    }
}
