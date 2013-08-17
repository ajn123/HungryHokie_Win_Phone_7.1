using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Newtonsoft.Json;
using System.Windows.Media.Imaging;


namespace VTHungryHokies
{
    public partial class MainPage : PhoneApplicationPage
    {


        private DiningCenters diningCenters;
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        // Handle selection changed on ListBox
        private void MainListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected index is -1 (no selection) do nothing
            if (MainListBox.SelectedIndex == -1)
                return;

            // Navigate to the new page
            NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + MainListBox.SelectedIndex, UriKind.Relative));

            // Reset selected index to -1 (no selection)
            MainListBox.SelectedIndex = -1;
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {

            dateTime.Text = "Last Time Updated: " + DateTime.Now.ToShortTimeString();
             
            if (!App.ViewModel.IsDataLoaded)
            {
                string hungryHokieLink = "http://hungryhokie.com/api/retrieve.php?pid=ajn123&password=uGyaH4ob068Qs4V";
                System.Net.WebClient client = new System.Net.WebClient();
                client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
                client.DownloadStringAsync(new Uri(hungryHokieLink));
            }
        }


        private void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                return;
            }
            diningCenters = JsonConvert.DeserializeObject<DiningCenters>(e.Result);

            if (diningCenters.Centers.Length == 0)
            {
                App.ViewModel.Items.Add(new ItemViewModel { LineOne = "Go shopping", LineTwo = "Nothing is Open!",  });

            }
            else
            {

                for (int i = 0; i < diningCenters.Centers.Length; i++)
                {
                    App.ViewModel.Items.Add(new ItemViewModel { LineOne = diningCenters.Centers[i].name, LineTwo = diningCenters.OpenAndClose(i), LineThree =
                  new BitmapImage(new Uri(diningCenters.Centers[i].image, UriKind.Absolute))
                             });

                }

           }

            App.ViewModel.IsDataLoaded = true;

        }

      
        private void AboutButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Assets/About.xaml", UriKind.Relative));

        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            App.ViewModel.IsDataLoaded = false;
            App.ViewModel.Items.Clear();
            MainPage_Loaded(null, null);
        }
    }









}