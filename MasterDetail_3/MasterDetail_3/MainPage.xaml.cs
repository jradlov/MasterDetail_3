using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MasterDetail_3
{
    public partial class MainPage : MasterDetailPage
    {
        private List<MyMenuItem> _menuItems;

        public MainPage()
        {
            InitializeComponent();

            _menuItems = new List<MyMenuItem> {
                new MyMenuItem {Name="Page1", Image="robot_purple.png"},
                new MyMenuItem {Name="Page2", Image="robot_gray.png"}
            };

            // each MyMenuItem in _menuItems is the Binding Context
            // for its corresponding item in ItemsSource
            masterListView.ItemsSource = _menuItems; 


            // first thing shown is a Detail Page.  Set this page here
            Detail = new NavigationPage(new Page1());
            IsPresented = false;  // present master page?
        }

        private void masterListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // without this check the app crashes - why ???
            if (e.SelectedItem == null) return;

            var menuChoice = e.SelectedItem as MyMenuItem;
            //DisplayAlert("menuChoice", menuChoice.Name, "Ok");

            string str = menuChoice.Name;

            if (str == _menuItems[0].Name)
                Detail = new NavigationPage(new Page1());
            else if (str == _menuItems[1].Name)
                Detail = new NavigationPage(new Page2());

            IsPresented = false;  // present master page?

            // To deselect the item (otherwise it's highlighted when clicked on)
            masterListView.SelectedItem = null;
        }
    }
}
