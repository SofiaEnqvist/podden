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
            
            //ska inte ligga här egentligen?
            updateCb();
        }

       
        public void updateCb()
        {
            cbChangeCategory.Items.Clear();
            CbAllCategory.Items.Clear();

            var list = Service.GetAllCategory();
            if (list != null)
            {
                foreach (var name in list)
                {
                    CbAllCategory.Items.Add(name);
                    cbChangeCategory.Items.Add(name);
                }
            }
        }

        //TODO: + Validering på stora och små bokstäver?
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
                    updateCb();
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
            
       //TODO: Den får inte tas bort om det finns feed under kategorin. Ej testad.
        //TODO: + Visa listan feedName, som har kategorin. 
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
           
            if (!String.IsNullOrEmpty(CbAllCategory.Text))
            {
                // kollar om kategorin finns i någon av feed.
                List<string> FeedName = MyValidation.CategoryUse(CbAllCategory.Text);

                // Om lista är null så kan kategorin tas bort.
                if (FeedName == null)
                {
                    Service.DeleteCategory(CbAllCategory.Text);
                    MessageBox.Show("Kategorin" + " " + CbAllCategory.Text + " " + "är nu borttagen");
                    updateCb();
                }

                // Finns det feedName så kanske det vora snyggt att presdentera vilka feeds de måste ta bort. 
                else
                {
                    MessageBox.Show("Du kan inte tabort en kategori som innehåller feeds");
                }
            }

            else
            {
                MessageBox.Show("välj vilken kategori du vill tabort");
            }
        }

        //TODO: Ändras även i feeden. 

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {

            if (!String.IsNullOrEmpty(cbChangeCategory.Text) && !String.IsNullOrEmpty(tbNewCategory.Text))
            {
                bool check = MyValidation.CategoryAlredy(tbNewCategory.Text);

                if (check == false)
                {

                    Service.ChangeCategory(cbChangeCategory.Text, tbNewCategory.Text);
                    tbNewCategory.Clear();
                    MessageBox.Show("Kategorin" + " " + cbChangeCategory.Text + " " + "är nu ändrad");
                    updateCb();
                }

                else
                {
                    MessageBox.Show("Det finns redan en kategori med detta namn");
                    tbNewCategory.Clear();
                    updateCb();
                }
            }

            else
            {
                MessageBox.Show("Då måste välja kategori och ett nytt namn");
            }

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


               
            }
            
        }
