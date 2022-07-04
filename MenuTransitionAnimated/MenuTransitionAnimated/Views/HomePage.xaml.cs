using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MenuTransitionAnimated.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public ObservableCollection<Menu> MenuItems { get; set; }

        public HomePage()
        {
            InitializeComponent();
            MenuItems = GetMenus();
            BindingContext = this;
        }

        private ObservableCollection<Menu> GetMenus()
        {
            return new ObservableCollection<Menu>
            {
                new Menu { Title = "Home", Icon = "home.png" },
                new Menu { Title = "Explore", Icon = "compass.png" },
                new Menu { Title = "Favourite", Icon = "heart.png" },
                new Menu { Title = "Music", Icon = "music.png" },
                new Menu { Title = "Share", Icon = "share.png" },
                new Menu { Title = "Settings", Icon = "settings.png" }
            };
        }

        private async void Show()
        {
            _ = TitleText.FadeTo(0);
            _ = MenuItemsView.FadeTo(1);
            _ = await MainMenuView.RotateTo(0, 300, Easing.BounceOut);
        }

        private async void Hide()
        {
            _ = TitleText.FadeTo(1);
            _ = MenuItemsView.FadeTo(0);
            _ = await MainMenuView.RotateTo(-90, 300, Easing.BounceOut);
        }

        private void ShowMenu(object sender, System.EventArgs e)
        {
            Show();
        }

        private void MenuTapped(object sender, System.EventArgs e)
        {
            TitleText.Text = ((sender as StackLayout).BindingContext as Menu).Title;
            Hide();
        }
    }
}
