using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RssReader.Logic;
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
           
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(tbSearch.Text))
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

            if (!string.IsNullOrEmpty(tbSearch.Text))
            {
                bool res = MyValidation.isSubscribedAlredy(tbSearch.Text, tbTitle.Text);

                if (res == false)
                {
                    Manage.AddSubManage(tbSearch.Text);
                    MessageBox.Show("Podcasten är tillagd!");

                    tbSearch.Clear();
                    tbTitle.Text = "";
                    tbCountAps.Text = "";
                    tblAbout.Text = "";
                }

                else
                {
                    MessageBox.Show("Du prenumererar redan på denna podcast!");
                }
            }
        }

        private void btGoToSub_Click(object sender, RoutedEventArgs e)
        {
            new Subscriptions().Show();
            this.Close();
        }

        private void btGoToSett_Click(object sender, RoutedEventArgs e)
        {
            //LÄgg till så att man kommer till settings.show()
        }
    }
}
