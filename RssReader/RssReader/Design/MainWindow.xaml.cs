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
using System.Windows.Navigation;
using System.Windows.Shapes;
using RssReader.Logic;
using RssReader.Logic.Service;

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
        //TODO: se till att prenumerreraknapen inte går att använda om man inte först har sökt efter podcasten, det blir ett kryphål där annars
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
          var loadedRss = Service.getRssByUri(tbSearch.Text);
          if (loadedRss.Title != null)
          {
              var title = loadedRss.Title.Text;
              tbTitle.Text = title;
              var about = loadedRss.Description.Text;
              tblAbout.Text = about;
              var count = loadedRss.Items.Count();
              tbCountAps.Text = count.ToString(); 
          }
          else
          {
              MessageBox.Show("Kunde inte hitta sökvägen.");
          }
        }

        //Prenumerera på en pocast, sparas ner som xml i .xml
        //To DO: validering om url finns
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // var hej = MethodTest.getAllSubscriptions();
            bool res = MyValidation.isSubscribedAlredy(tbSearch.Text, tbTitle.Text);

            if (res == false) {
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
            
            
            
            //Vad ska hända när den ska prenumereras på?
            // podfeeden ska sparas ner som xml
            //- validering om att den inte redan är tillagd.
            //podavsnitten ska läggas in under överlement, sparas under namnet på podden
        }
    }
}
