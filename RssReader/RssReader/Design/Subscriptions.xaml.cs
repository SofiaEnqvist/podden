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
        //Lägg alla svasnitt snyggt :
        // 1. Podcastnamnet
        //2. Beskrivning av podcasten
        //3.Antal avsnitt
        //4.Tryck på podcasten och kom till listan med alla avsnitt
        
        private void Subscriptions_OnLoad(object sender, RoutedEventArgs e)
        { 
           var list =  MethodTest.getAllSubs();
           foreach (var name in list)
           {
               listBoxSubscription.Items.Add(name);
           }     
        }

        private void listBoxSubscription_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //MP3 grejen funkar !! nu ska vi bara få in den på varje knapp som kommer upp i listan.
           // Process.Start("wmplayer.exe", "http://rss.acast.com/varvet/-197-darinzanyar/media.mp3");
            //!!!

            lboxSubEp.Items.Clear();
            var selectedItem = listBoxSubscription.SelectedItem.ToString();
           Feed feed =  Manage.getSelectedSub(selectedItem);
            foreach(var item in feed.PodList)
            {
                lboxSubEp.Items.Add(item.Title);
                lboxSubEp.Items.Add(item.Content);
                lboxSubEp.Items.Add(item.PubDate.Date);
                lboxSubEp.Items.Add(item.Mp3Link);
                //Här ska mp3grejen hamna, TODO  gör om så att rätt länk sparas i podcastEs, dvs .mp3-filen
                var btn = new Button();
                btn.Content = "Lyssna på avsnittet";
                lboxSubEp.Items.Add(btn);
                lboxSubEp.Items.Add("----------------------------------------");
            }


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


        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    var subscriptionList = TesatMetodKlass.getAllSubscriptions();


        //        foreach (var item in subscriptionList)
        //        {
        //            tblSubscriptions.Text +=  item.Title;

        //        }


        //}
        
    }
}
