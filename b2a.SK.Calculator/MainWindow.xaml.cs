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

namespace b2a.SK.Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        
        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            UpdateNewValue(7);
        }

        private void UpdateNewValue(int number)
        {
            int origional = 0;
            int newValue = number;
            if (string.IsNullOrEmpty(txtValue.Text) == false)
            {
                origional = Convert.ToInt32(txtValue.Text);
            }

            newValue = origional * 10 + number;
            txtValue.Text = newValue.ToString();
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            UpdateNewValue(8);
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            UpdateNewValue(9);
        }
    }
}
