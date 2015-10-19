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
using RssReader.Entity;
using RssReader.Data;
using System.Xml.Serialization;

using System.IO;
using RssReader.Logic;
using RssReader.Logic.Service;
using System.Xml;


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

        }

        //private void Settings_OnLoad(object sender, RoutedEventArgs e)
        //{
        //    var list = Service.GetAllCategory();
        //    foreach (var name in list)
        //    {
        //        CbAllCategory.Items.Add(name);
        //    }
        //}

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            
            string Filepath = "c:\\temp\\Category.xml";

            if (!File.Exists(Filepath))
            {
                File.Create(Filepath).Close();
            }

            if (!String.IsNullOrEmpty(tbCategory.Text))
            {
                bool check = MyValidation.CategoryAlredy(tbCategory.Text);
              
                if (check == false)
                {
                    List<string> list = new List<string>();
                    list.Add(tbCategory.Text);

                    Category c = new Category(); 
                    {
                        c.CategoryName = list;
                    }
                   

                    Service.AddCategory(c);
                    MessageBox.Show("Kategorin" + " " + tbCategory.Text + " " + "är nu tillagd");
                    tbCategory.Clear();
                }

                else
                {
                    MessageBox.Show("Kategorin finns redan");
                    tbCategory.Clear();
                }
             
        
            }
        }


        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var ser = new XmlCategory();
            var list = ser.DezerializeCategory();

          

            //if (!String.IsNullOrEmpty(CbAllCategory.Text))
            //{

            //    Service.DeleteCategory(CbAllCategory.Text);

            //    new Settings().Show();
            //    this.Close();
            //}

            //else
            //{
            //    MessageBox.Show("Välj Kategori");
            //}

            //var ser = new XmlCategory();
            //ser.DezerializeCategory();

        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            // Ändra categorinamnet. 
 
        }


               
            }
            
        }
