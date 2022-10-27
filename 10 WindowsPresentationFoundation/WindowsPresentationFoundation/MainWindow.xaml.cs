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

namespace WindowsPresentationFoundation
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

        private void SplitButton_Click(object sender, RoutedEventArgs e)
        {
            spltList.Items.Clear();
            string str = spltText.Text;
            string[] words = str.Split(' ');
            foreach (string word in words)
            {
                spltList.Items.Add(word);
            }
        }
        private void ReverseButton_Click(object sender, RoutedEventArgs e)
        {
            string str = rvrsText.Text;
            string[] words = str.Split(' ');
            string output = "";
            for (int i = words.Length - 1; i >= 0; i--)
            {
                output += words[i] + " ";
            }
            rvrsLabel.Content = output;
        }
    }
}
