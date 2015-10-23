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
            cbChangeCategory.Items.Clear();

            var cbItems = Service.GetAllCategory();
            if (cbItems.CategoryName != null)
            {
                foreach (var name in cbItems.CategoryName)
                {
                    CbAllCategory.Items.Add(name);
                    cbChangeCategory.Items.Add(name);
                    
                }
            }

            //var list = Service.GetAllCategory();
            //if (list != null)
            //{
            //    foreach (var name in list)
            //    {
            //        CbAllCategory.Items.Add(name);
            //        cbChangeCategory.Items.Add(name);
            //    }
            //}
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        { 
            if (!String.IsNullOrEmpty(tbCategory.Text))
            {
                bool check = MyValidation.CategoryAlredyExist(tbCategory.Text.ToUpper());

                if (check == false)
                {
                    Service.Ser_Add(tbCategory.Text.ToUpper());
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

            tbCategory.Clear();
            updateCb();
            
        }
            
       
        //TODO: + Visa listan feedName, som har kategorin. 
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
           
            if (!String.IsNullOrEmpty(CbAllCategory.Text))
            {
                // Listar namnet på dem feeds som använder kategorin som försöker tas bort. 
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


       
        // Change category name. 
        private void btnChange_Click(object sender, RoutedEventArgs e)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void CbAllCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }



               
            }
            
        }
