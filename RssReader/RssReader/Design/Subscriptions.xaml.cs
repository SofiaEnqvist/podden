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

        //private void Subscriptions_OnLoad(object sender, RoutedEventArgs e)
        //{ //Lägg alla svasnitt snyggt :
        //    // 1. Podcastnamnet
        //    //2. Beskrivning av podcasten
        //    //3.Antal avsnitt
        //    //4.Tryck på podcasten och kom till listan med alla avsnitt
        
        //    var subscriptionList = TesatMetodKlass.getAllSubscriptions();
        //    var number = 1;
        //    while (number < 10)
        //    {
        //        foreach (var item in subscriptionList)
        //        {
        //            tblSubscriptions.Text = number.ToString();
        //        }
        //        number++;
        //    }
        //}

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var subscriptionList = TesatMetodKlass.getAllSubscriptions();
            
           
                foreach (var item in subscriptionList)
                {
                    tblSubscriptions.Text +=  item.Title;

                }
                
            
        }
        
    }
}
