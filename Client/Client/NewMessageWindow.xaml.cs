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
    /// Interaction logic for NewMessageWindow.xaml
    /// </summary>
    public partial class NewMessageWindow : Window
    {

        private const string _pathToServer = @"https://localhost:44333/";

        public NewMessageWindow()
        {
            InitializeComponent();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

            LetterDTO letterToSend = new LetterDTO(messageTheme.Text, (int?) Int32.Parse(senderId.Text), (int?)Int32.Parse(recieverId.Text), DateTime.Now, messageContent.Text);
            Send(letterToSend);
        }

        private async Task Send(LetterDTO letter)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(_pathToServer + "api/values", letter);
            }
        }

    }
}
