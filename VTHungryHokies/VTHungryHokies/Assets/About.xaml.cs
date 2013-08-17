using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Shapes;
using Microsoft.Phone.Tasks;
namespace VTHungryHokies.Assets
{
    public partial class About : PhoneApplicationPage
    {
        public About()
        {
            InitializeComponent();
            this.textBlock1.Text = "Version 1.0\r\n\r\n Built by  Alex Norton Approved from original HH creator Alex Obenauer \r\n\r\n Never Never Never give up.";


        }




        private void Suggestion_Click(object sender, EventArgs e)
        {
            Microsoft.Phone.Tasks.EmailComposeTask emailTask = new Microsoft.Phone.Tasks.EmailComposeTask();
            emailTask.Subject = "Suggestion for HungryHokie v1.0";
            emailTask.To = "applejuiceteaching@gmail.com";
            emailTask.Show();

        }

        private void More_Click(object sender, EventArgs e)
        {
            WebBrowserTask task = new WebBrowserTask();
            task.Uri = new Uri("http://www.applejuicescholars.com", UriKind.Absolute);
            task.Show();
        }

     

    }
}