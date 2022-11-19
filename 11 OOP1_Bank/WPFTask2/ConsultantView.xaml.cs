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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFTask2
{
    /// <summary>
    /// Логика взаимодействия для ConsultantView.xaml
    /// </summary>
    public partial class ConsultantView : UserControl
    {
        protected Client client;

        public ConsultantView()
        {
            InitializeComponent();
        }

        protected void Butt_Download_Click(object sender, RoutedEventArgs e)
        {
            client = new Client().Deserialize("client.json");
            this.text_surname.Text = client.surname;
            this.text_name.Text = client.name;
            this.text_secondname.Text = client.secondName;
            this.text_phone.Text = client.phoneNumber;
            if (client.passportNumber != "") {
                this.text_passport.Text = "****************";
            }
        }

        protected void butt_phone_Click(object sender, RoutedEventArgs e)
        {
            if (client != null)
            {
                if (this.butt_phone.Content.ToString() == "chng")
                {
                    this.text_phone.Focusable = true;
                    this.butt_phone.Content = "save";
                }
                else if (this.text_phone.Text == "")
                {
                    MessageBox.Show("Telephone Number can not be empty");
                }
                else
                {
                    this.text_phone.Focusable = false;
                    this.butt_phone.Content = "chng";
                    client.phoneNumber = this.text_phone.Text;
                }
            }
            else
            {
                MessageBox.Show("Download the Client file");
            }
        }

        protected void Butt_Save_Click(object sender, RoutedEventArgs e)
        {
            if(client != null)
            {
                client.Serialize("client.json");
            }
            else
            {
                MessageBox.Show("Download the Client file");
            }
        }
    }
}
