using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using RssReader.Logic;
using RssReader.Entity;
using RssReader.Logic.Service;


namespace RssReader.Design
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
            //ska inte ligga här egentligen, en onload metod. 
            updateCb();
        }


        public void updateCb()
        {
            CbAllCategory.Items.Clear();
            CbCategory.Items.Clear();
            cbAllFeed.Items.Clear();
            cbIntervall.Items.Clear();
            tbCategory.Clear();
            tbFeedName.Clear();
            tbNewCategory.Clear();
            tbURL.Clear();

            var cbItems = Service.GetAllCategory();
            var cbFeed = Service.Ser_getTitleAllSubs();
            var cbInter = Manage.fillCbInterval();

            if (cbItems.CategoryName != null)
            {
                foreach (var name in cbItems.CategoryName)
                {
                    CbAllCategory.Items.Add(name);
                    CbCategory.Items.Add(name);
                }
            }

            if (cbFeed != null)
            {
                foreach (var name in cbFeed)
                {
                    cbAllFeed.Items.Add(name);
                }
            }

            if (cbInter != null)
            {
                foreach (var interval in cbInter)
                {
                    cbIntervall.Items.Add(interval);
                }
            }

        }

        private void btnAddCategory_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tbCategory.Text))
            {
                bool check = MyValidation.CategoryAlredyExist(tbCategory.Text.ToUpper());

                if (check == false)
                {
                    Service.Ser_AddCategory(tbCategory.Text.ToUpper());
                    MessageBox.Show("Kategorin" + " " + tbCategory.Text + " " + "är nu tillagd");
                }
                else
                {
                    MessageBox.Show("Kategorin finns redan");
                }
            }

            else
            {
                MessageBox.Show("Fyll i en Kategori");
            }
            updateCb();
        }


        //TODO: + Visa listan feedName, som har kategorin, alt ta bort även feeds. 
        private void btnDeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(CbAllCategory.Text))
            {
                List<string> FileName = MethodTest.getAllSubs();
                bool check = MyValidation.CategoryUse(CbAllCategory.Text, FileName);

                if (check == true)
                {
                    List<string> FeedName = Service.GetAllCategorysFeed(FileName, CbAllCategory.Text);

                    //string test;

                    //for (int i = 0; i < FeedName.Count; i++)
                    //{
                    //    test = FeedName[i] + ",";
                    //}

                    MessageBox.Show("Kategorin kan inte tas bort den innehåller feeds");
                }

                else
                {
                    Service.DeleteCategory(CbAllCategory.Text);
                    MessageBox.Show("Kategorin" + " " + CbAllCategory.Text + " " + "är nu borttagen");
                }
            }

            else
            {
                MessageBox.Show("Välj vilken kategori du vill tabort");
            }
            updateCb();
        }


        private void btnSaveCategory_Click(object sender, RoutedEventArgs e)
        {

            if (!String.IsNullOrEmpty(CbAllCategory.Text) && !String.IsNullOrEmpty(tbNewCategory.Text))
            {
                bool check = MyValidation.CategoryAlredyExist(tbNewCategory.Text.ToUpper());

                if (check == false)
                {
                    List<string> FileName = MethodTest.getAllSubs();
                    bool FeedName = MyValidation.CategoryUse(CbAllCategory.Text, FileName);
                    
                    if(FeedName == true)
                    {
                        List<string> Feeds = Service.GetAllCategorysFeed(FileName, CbAllCategory.Text);
                        Service.ChangeCategory(CbAllCategory.Text, tbNewCategory.Text.ToUpper());
                        Service.ChangeFeed(Feeds, tbNewCategory.Text.ToUpper());   
                    }

                    else
                    {
                        Service.ChangeCategory(CbAllCategory.Text, tbNewCategory.Text.ToUpper());
                    }

                    MessageBox.Show("Kategorin" + " " + CbAllCategory.Text + " " + "är nu ändrad");
                }

                else
                {
                    MessageBox.Show("Det finns redan en kategori med detta namn");
                }
            }

            else
            {
                MessageBox.Show("Då måste välja kategori och ett nytt kategori namn");
            }

            tbNewCategory.Clear();
            updateCb();
        }


        // Finns säkert bättre sätt att kolla vad som är ändrat. 
        private void btnSaveFeed_Click(object sender, RoutedEventArgs e)
        {
            Feed Feed = Service.Ser_getSelectedSub(cbAllFeed.Text);
            var interval = cbIntervall.SelectedItem.ToString();
            int x = MyValidation.ConvertStringToInt(interval);

            if (Feed.URL != tbURL.Text)
            {
                //MyValidation.doesURLExists(URL);
                List<string> AllSub = MethodTest.getAllSubs();
                bool SubscribeAlredy = MyValidation.isSubscribedAlredy(AllSub, tbURL.Text);
            
                if (SubscribeAlredy == false)
                {
                    if (Feed.Name != tbFeedName.Text)
                    {
                        bool FeedNameExists = MyValidation.FeedNameExists(tbFeedName.Text, AllSub);

                        if (FeedNameExists == true)
                        {
                            MessageBox.Show("Du har redan en feed med detta namn");
                            tbFeedName.Clear();
                        }
                    }
                        Service.ChangeFeed(tbURL.Text, tbFeedName.Text, CbCategory.Text, x);
                        MessageBox.Show(cbAllFeed.Text + " " + "är nu ändrad");
                        updateCb();
                }

                else
                {
                    MessageBox.Show("Du prenummerar redan på" + " " + tbURL.Text);
                    updateCb();
                }


            }

            else
            {
                if (Feed.Name != tbFeedName.Text)
                {
                    List<string> AllSub = MethodTest.getAllSubs();
                    bool FeedNameExists = MyValidation.FeedNameExists(tbFeedName.Text, AllSub);

                    if (FeedNameExists == true)
                    {
                        MessageBox.Show("Du har redan en feed med detta namn");
                        tbFeedName.Clear();
                    }
                }
                    Service.ChangeFeed(tbURL.Text, tbFeedName.Text, CbCategory.Text, x);
                    MessageBox.Show(cbAllFeed.Text + " " + "är nu ändrad");
                    updateCb();
            }          
        }

        private void btnDeleteFeed_Click(object sender, RoutedEventArgs e)
        {
            Service.DeleteFeed(cbAllFeed.Text);
            MessageBox.Show(cbAllFeed.Text + " " + "är nu borttagen");
            updateCb();
        }


        // TODO: testa mer. 
        private void CbAllCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbAllCategory.SelectedItem != null)
            {
                tbNewCategory.Text = CbAllCategory.SelectedItem.ToString();
            }
        }

        // TODO: testa mer. 
        private void cbAllFeed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbAllFeed.SelectedItem != null)
            {
                var des = Service.Ser_getSelectedSub(cbAllFeed.SelectedItem.ToString());
                tbFeedName.Text = des.Name;
                tbURL.Text = des.URL;
                CbCategory.Text = des.Category;
                cbIntervall.Text = des.Interval.ToString() + " min";
            }
        }

        private void MySubscriptions_Click(object sender, RoutedEventArgs e)
        {
            new Subscriptions().Show();
            this.Close();
        }


        private void Subscribe_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }
    }
}
