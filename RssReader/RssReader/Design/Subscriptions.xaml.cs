using System;
using System.Windows;
using System.Windows.Controls;
using RssReader.Logic;
using RssReader.Entity;
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
            try
            {
                UpdateInterval.getIntervalInt();
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void listBoxSubscription_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lViewSub.Items.Clear();
            {
                try
                {
                    var selectedItem = listBoxSubscription.SelectedItem.ToString();
                    Feed feed = Manage.Man_getSelectedSub(selectedItem);
                    foreach (var item in feed.PodEp)
                    {
                        if (item.Status == 1)
                        {
                            lViewSub.Items.Add("------------------------\r\n"
                                + item.Title + "\r\n"
                                + item.Content + "\r\n"
                                + item.PubDate.ToString()
                                + " \r\n Lyssnad på \r\n");
                        }
                        else if (item.Status == 0)
                        {
                            lViewSub.Items.Add("------------------------\r\n"
                                + item.Title + "\r\n"
                                + item.Content + "\r\n"
                                + item.PubDate.ToString()
                                + " \r\n Olyssnad på \r\n");
                        }
                        lViewSub.Items.Add(item.Mp3Link);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        private void cbFilterCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbFilterCategory.SelectedIndex != 0)
            {
                var selected = cbFilterCategory.SelectedItem;
                var list = Manage.Man_GetSelFeed(selected);
                if (list.Count != 0)
                {
                    listBoxSubscription.Items.Clear();
                    foreach (var item in list)
                    {
                        listBoxSubscription.Items.Add(item);
                    }
                }
                else
                {
                    MessageBox.Show("Det finns inga sparade podkasts i denna kategori.");
                    listBoxSubscription.Items.Clear();
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

        //TODO: Validering eller att det ej går tt klicka på annat än länken när man vill spela upp. 
        //ändra i xml till Status == 1
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            var val = lViewSub.SelectedItem.ToString();

            char[] MyChar = { '"' };
            string NewString = val.TrimStart(MyChar);
            Console.WriteLine(NewString);
            try
            {
                Process.Start(NewString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

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


    }
}
