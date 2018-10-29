using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using Client.Models;

namespace Client
{
    /// <summary>
    /// Interaction logic for DeleteWindow.xaml
    /// </summary>
    public partial class DeleteWindow : Window
    {
        private const string _pathToServer = @"https://localhost:44333/";
        public DeleteWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var id = Int32.Parse(letterId.Text);
            await DeleteLetter(id);
            MessageBox.Show("Completed");
            
        }

        private async Task DeleteLetter(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync(_pathToServer + $"api/values/{id}");
            }
        }
    }
}
