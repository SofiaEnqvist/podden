using RssReader.Entity;
using RssReader.Logic;
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

namespace RssReader.Design
{
    /// <summary>
    /// Interaction logic for AddSubscription.xaml
    /// </summary>
    public partial class AddSubscription : Window
    {


        public AddSubscription()
        {
            InitializeComponent();


        }
        public AddSubscription(string para1, string para2)
        {
            InitializeComponent();
            this.searchString = para1;
            this.titleString = para2;
        }


        //TODO: om det inte finns några kategorier så ska en defultkategori läggas till?
        //För väljs icke en kategori kraschar det
        private void AddSubscription_OnLoad(object sender, RoutedEventArgs e)
        {
            var cbItems = Logic.Manage.fillCb();
            //if (cbItems.CategoryName == null)
            //{ 
            //    var def = "default";
            //    Category cat = new Category();
            //    cat.CategoryName.Add(def);

            //}
            foreach (var item in cbItems.CategoryName)
            {
                cbCategory.Items.Add(item);
            }
        }

        //TODO: en jäkla massa if-satser, testa testa så alla går rätt. Om det finns tid så kanske försök hitta nått sätt
        //där en miljon if-satser inte behövs.
        private void btnOkej_Click(object sender, RoutedEventArgs e)
        {
            var feedName = tbFeedName.Text;
            var valCat = cbCategory.SelectedItem;
            var valInterval = cbInterval.SelectedItem;


            if (!string.IsNullOrEmpty(feedName))
            {
                var res1 = MyValidation.feedNameExists(titleString, feedName);
                if (res1 == false)
                {
                    if (valCat != null)
                    {
                        bool res = MyValidation.isSubscribedAlredy(searchString, titleString);

                        if (!string.IsNullOrEmpty(searchString))
                        {
                            if (res == false)
                            {
                                Manage.AddSubManage(searchString, feedName, valCat.ToString());
                                MessageBox.Show("Podcasten är tillagd!");
                            }

                            else
                            {
                                MessageBox.Show("Du prenumererar redan på denna podcast!");
                            }
                        }
                        this.Close();
                    }

                    else
                    {
                        MessageBox.Show("Välj en kategori!");
                    }
                }
                else
                {
                    MessageBox.Show("Namnet är upptaget!");
                }
            }
            else
            {
                MessageBox.Show("Fyll i ett namn");
            }
        }


        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        public string searchString { get; set; }
        public string titleString { get; set; }
    }
}
