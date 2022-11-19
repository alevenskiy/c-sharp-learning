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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Tab_Control_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(this.Tab_Control.SelectedIndex == 0)
            {
                ConsultantView consultant_view = new ConsultantView();
                this.Cons_Tab.Content = consultant_view;
            }
            else
            {
                ManagerView manager_view = new ManagerView();
                this.Mana_Tab.Content = manager_view;
            }
        }
    }
}
