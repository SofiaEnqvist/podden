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
using System.Net.Http;

namespace RssReader.Design
{
    /// <summary>
    /// Interaction logic for testAsync.xaml
    /// </summary>
    public partial class testAsync : Window
    {
        public testAsync()
        {
            InitializeComponent();
        }

        async Task<int> AccessTheWebAsync()
        {
            HttpClient client = new HttpClient();
            Task<string> getStringTask = client.GetStringAsync("http://msdn.microsoft.com");
            DoIndWork();

            string urlCont = await getStringTask;
            Console.WriteLine(urlCont.Length);
            return urlCont.Length;
        }

        private void DoIndWork()
        {
            resultsTextBox.Text += "Working.......\r\n";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           var hej =  AccessTheWebAsync();
        }
    }
}
