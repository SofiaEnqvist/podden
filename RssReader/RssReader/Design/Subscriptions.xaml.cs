﻿using System;
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


            lViewSub.Items.Clear();
            var selectedItem = listBoxSubscription.SelectedItem.ToString();
           Feed feed =  Manage.getSelectedSub(selectedItem);
            foreach(var item in feed.PodEp)
            {
                lViewSub.Items.Add(item.Title + "\r\n" + item.Content + "\r\n" + item.PubDate.ToString());
                lViewSub.Items.Add(item.Mp3Link);
               

                //lViewSub.Items.Add(item.Content);
                //lViewSub.Items.Add(item.PubDate.Date);
                //lViewSub.Items.Add(item.Mp3Link);
               // //Här ska mp3grejen hamna, TODO  gör om så att rätt länk sparas i podcastEs, dvs .mp3-filen
               // var btn = new Button();
               // btn.Content = "Lyssna på avsnittet";
               // lboxSubEp.Items.Add(btn);
               // lbo xSubEp.Items.Add("----------------------------------------");
                
                //tblSubs.Text += item.Title + "\r\n";
                //tblSubs.Text += item.Content + "\r\n";
                //tblSubs.Text += item.PubDate.ToString() + "\r\n";
                //tblSubs.Text += "\r\n";
                //tblSubs.Text += item.Mp3Link + "\r\n \r\n";
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

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            var val = lViewSub.SelectedItem.ToString();

            
            char[] MyChar = { '"' };
            string NewString = val.TrimStart(MyChar);
            Console.WriteLine(NewString);
            Process.Start(NewString);
            Process.Start("wmplayer.exe", "http://rss.acast.com/varvet/-197-darinzanyar/media.mp3");
            
        }
        
    }
}
