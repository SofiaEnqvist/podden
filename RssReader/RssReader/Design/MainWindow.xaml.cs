using System;
using System.Linq;
using System.Windows;
using RssReader.Logic.Service;
using RssReader.Design;

namespace RssReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Data.Class2 cl = new Data.Class2();
            cl.doSomething();
            var hej = new RssReader.Logic.MyValidation();
            hej.isInt("uhde8");
     
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tbSearch.Text))
            {
                BtnSubscribe.IsEnabled = true;
                var loadedRss = Service.getRssByUri(tbSearch.Text);
                if (loadedRss.Title != null)
                {
                    tbTitle.Text = loadedRss.Title.Text;
                    tblAbout.Text = loadedRss.Description.Text;
                    tbCountAps.Text = loadedRss.Items.Count().ToString();
                }
                else
                {
                    MessageBox.Show("Kunde inte hitta sökvägen.");
                    BtnSubscribe.IsEnabled = false;
                }
            }
            else
            {
                MessageBox.Show("Fyll i sökfältet.");
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new AddSubscription(tbSearch.Text, tbTitle.Text).Show();
            this.Close();
        }


        private void btGoToSub_Click(object sender, RoutedEventArgs e)
        {
            new Subscriptions().Show();
            this.Close();
        }


        private void btGoToSett_Click(object sender, RoutedEventArgs e)
        {
            new Settings().Show();
            this.Close();
        }
    }
}
