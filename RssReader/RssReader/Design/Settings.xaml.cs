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

            var list = Service.GetAllCategory();

            if (list != null)
            {
                foreach (var name in list)
                {
                    CbAllCategory.Items.Add(name);
                }
            }
        }


        private void Settings_OnLoad(object sender, RoutedEventArgs e)
        {
            var list = Service.GetAllCategory();

            if (list != null)
            {
                foreach (var name in list)
                {
                    CbAllCategory.Items.Add(name);
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
           
            if (!String.IsNullOrEmpty(tbCategory.Text))
            {
                bool check = MyValidation.CategoryAlredy(tbCategory.Text);

                if (check == false)
                {
                    Service.AddCategory(tbCategory.Text);
                    MessageBox.Show("Kategorin" + " " + tbCategory.Text + " " + "är nu tillagd");
                    tbCategory.Clear();
                }

                else
                {
                    MessageBox.Show("Kategorin finns redan");
                    tbCategory.Clear();
                }

            }
                else
                {
                    MessageBox.Show("Fyll i en Kategori");
                }
            
            }
            
        // Ej klar
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

            //if (!String.IsNullOrEmpty(CbAllCategory.Text))
            //{
            //    Service.DeleteCategory(CbAllCategory.Text);
            //    //cballcategory ska uppdateras. 
            //}

            //else
            //{
            //    MessageBox.Show("välj vilken kategori du vill tabort");
            //}
        }


        private void btnChange_Click(object sender, RoutedEventArgs e)
        {

            if (!String.IsNullOrEmpty(CbAllCategory.Text) && !String.IsNullOrEmpty(tbNewCategory.Text))
            {
                Service.ChangeCategory(CbAllCategory.Text, tbNewCategory.Text);
                tbNewCategory.Clear();
                //cbAllCategory ska uppdateras. 
            }

            else
            {
                MessageBox.Show("Då måste välja kategori och ett nytt namn");
            }

        }

        private void tbNewCategory_TextChanged(object sender, TextChangedEventArgs e)
       {

        }


               
            }
            
        }
