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
using RssReader.Logic.Service;
using RssReader.Data;
using System.Runtime.InteropServices;
using System.Diagnostics;



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
            tbCategory.Clear();
            tbFeedName.Clear();
            tbNewCategory.Clear();
            tbURL.Clear();

            var cbItems = Service.GetAllCategory();
            var cbFeed = Service.Ser_getTitleAllSubs();

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
        // Listar namnet på dem feed(feedname) som använder kategorin som försöker tas bort. 
        private void btnDeleteCategory_Click(object sender, RoutedEventArgs e)
        {

            if (!String.IsNullOrEmpty(CbAllCategory.Text))
            {

                List<string> FeedName = MyValidation.CategoryUse(CbAllCategory.Text);

                if (FeedName.Count() == 0)
                {
                    Service.DeleteCategory(CbAllCategory.Text);
                    MessageBox.Show("Kategorin" + " " + CbAllCategory.Text + " " + "är nu borttagen");
                }

                else
                {
                    string test;

                    for (int i = 0; i < FeedName.Count; i++)
                    {
                        test = FeedName[i] + ",";
                    }

                    MessageBox.Show("Kategorin kan inte tas bort den innehåller feeds");
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
                    List<string> FeedName = MyValidation.CategoryUse(CbAllCategory.Text);
                    Service.ChangeCategory(CbAllCategory.Text, tbNewCategory.Text.ToUpper());
                    Service.ChangeFeed(FeedName, tbNewCategory.Text.ToUpper());

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

        //Blir knas när man försöker tabort denna? 
        private void tbNewCategory_TextChanged(object sender, TextChangedEventArgs e)
        {

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
            }
        }


        private void btnSaveFeed_Click(object sender, RoutedEventArgs e)
        {
            Service.ChangeFeed(tbURL.Text, tbFeedName.Text, CbCategory.Text);
            MessageBox.Show(cbAllFeed.Text + " " + "är nu ändrad");
            updateCb();
        }

        private void btnDeleteFeed_Click(object sender, RoutedEventArgs e)
        {
            Service.DeleteFeed(cbAllFeed.Text);
            MessageBox.Show(cbAllFeed.Text + " " + "är nu borttagen");
            updateCb();
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
