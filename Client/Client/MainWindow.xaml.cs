using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
using Client.Models;
using Int32 = System.Int32;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string _pathToServer = @"https://localhost:44333/";
        

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var userID = Int32.Parse(inputId.Text);
            var letterList = await GetAllLettersForUser(userID);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NewMessageWindow newMessage = new NewMessageWindow();
            newMessage.Show();
        }

        private async Task<IEnumerable<LetterDTO>> GetAllLettersForUser(int id)
        {
            IEnumerable<LetterDTO> result;
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(_pathToServer + "api/values/");
                result = await response.Content.ReadAsAsync<IEnumerable<LetterDTO>>();
            }

            return result;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DeleteWindow delWindow = new DeleteWindow();
            delWindow.Show();
        }
    }





}
