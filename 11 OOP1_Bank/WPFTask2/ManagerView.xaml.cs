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

namespace WPFTask2
{
    /// <summary>
    /// Логика взаимодействия для ManagerView.xaml
    /// </summary>
    public partial class ManagerView : ConsultantView
    //C:\c-sharp\c-sharp-learning\11 OOP1_Bank\WPFTask2\ManagerView.xaml.cs(21,26,21,37):
    //error CS0263:
    //Разделяемые объявления "ManagerView" не должны указывать различные базовые классы.
    {

        Client client;
        public ManagerView()
        {
            InitializeComponent();
        }

        private void Butt_Download_Click(object sender, RoutedEventArgs e)
        {
            client = new Client().Deserialize("client.json");
            base.Butt_Download_Click(sender, e);
            this.text_passport.Text = client.passportNumber;
        }
    }
}