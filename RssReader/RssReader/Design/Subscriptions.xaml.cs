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
using System.Windows.Shapes;
using RssReader.Logic;
using RssReader.Entity;
using System.Runtime.InteropServices;
using System.Diagnostics;
using RssReader.Logic.Service;


namespace RssReader.Design
{
    /// <summary>
    /// Interaction logic for Subscriptions.xaml
    /// </summary>
    public partial class Subscriptions : Window
    {
        public Subscriptions()
        {
            InitializeComponent();
        }

        private void Subscriptions_OnLoad(object sender, RoutedEventArgs e)
        {
            
            UpdateInterval.Timer();
            var cbItems = Logic.Manage.fillCb();
            var defaultCat = "Alla kategorier";
            cbFilterCategory.Items.Add(defaultCat);
            foreach (var item in cbItems.CategoryName)
            {
                cbFilterCategory.Items.Add(item);
            }

            var list = Manage.Man_getTitleListSubscription();
            foreach (var name in list)
            {
                listBoxSubscription.Items.Add(name);
            }
        }

        private void listBoxSubscription_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            lViewSub.Items.Clear();
            var selectedItem = listBoxSubscription.SelectedItem.ToString();
            Feed feed = Manage.Man_getSelectedSub(selectedItem);
            foreach (var item in feed.PodEp)
            {
                lViewSub.Items.Add("------------------------\r\n" + item.Title + "\r\n" + item.Content + "\r\n" + item.PubDate.ToString());
                lViewSub.Items.Add(item.Mp3Link);
            }
        }


        //TODO: Validering eller att det ej går tt klicka på annat än länken när man vill spela upp. 
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            
            var val = lViewSub.SelectedItem.ToString();

            char[] MyChar = { '"' };
            string NewString = val.TrimStart(MyChar);
            Console.WriteLine(NewString);
            Process.Start(NewString);


            //Spelar upp mp3filer i win media player
            //Process.Start("wmplayer.exe", "http://rss.acast.com/varvet/-197-darinzanyar/media.mp3");

        }

        private void btGoToSub2_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void GoToSett_Click(object sender, RoutedEventArgs e)
        {
            new Settings().Show();
            this.Close();
        }

        private void cbFilterCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbFilterCategory.SelectedIndex != 0)
            {
                var selected = cbFilterCategory.SelectedItem;
                var list = Manage.Man_GetSelFeed(selected);
                foreach (var item in list)
                {
                    listBoxSubscription.Items.Clear();
                    listBoxSubscription.Items.Add(item);
                }

            }
            else
            {
                listBoxSubscription.Items.Clear();
                var list = Manage.Man_getTitleListSubscription();
                foreach (var name in list)
                {
                    listBoxSubscription.Items.Add(name);
                }
                
                
            }
        }
    }
}
