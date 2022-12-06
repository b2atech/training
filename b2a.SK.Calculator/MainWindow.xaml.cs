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

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button) sender ;
            int number = int.Parse(button.Content.ToString());
            UpdateNewValue(number);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                txtMessage.Text = "Name is mandatory, please add name!";
                return;
            }
            if (lstNames.Items.Contains(txtName.Text))
            {
                txtMessage.Text = "Name already exist, please add new name!";
                return;
            }
            if (txtName.Text.Trim().IndexOf(' ') < 0)
            {
                txtMessage.Text = "Name is invalid, there should be at least one space in your name!";
                return;
            }

            lstNames.Items.Add(txtName.Text);
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

       
    }
}
