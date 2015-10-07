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
using System.Windows.Navigation;
using System.Windows.Shapes;
using RssReader.Logic;

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
           TesatMetodKlass.getRss();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            //Skicka searchString till en metod som letar efter podden om den finns.. hur gör man det då?
           var about = TesatMetodKlass.getRss(tbSearch.Text);
           tblAbout.Text = about;
           var count = TesatMetodKlass.countPodEps(tbSearch.Text);
           tbCountAps.Text = count.ToString(); 

        }
    }
}
