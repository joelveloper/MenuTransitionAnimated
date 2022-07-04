using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MenuTransitionAnimated.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Menu> MenuItems { get; set; }

        public MainPage()
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
                new Menu { Title = "Share", Icon = "share.png"}
            };
        }

        private async void Show()
        {
            _ = await MainMenu.TranslateTo(300, 100, 700, Easing.BounceOut);
        }

        private async void Hide()
        {
            _ = await MainMenu.TranslateTo(0, 0, 700, Easing.BounceOut);
        }

        private void ShowMenu(object sender, EventArgs e)
        {
            Show();
        }

        private void MenuTapped(object sender, EventArgs e)
        {
            SubtitleText.Text = ((sender as StackLayout).BindingContext as Menu).Title;
            Hide();
        }
    }

    public class Menu
    {
        public string Title { get; set; }
        public string Icon { get; set; }
    }
}
