using B2A.ToDoItemsDemo.Model;
using B2A.ToDoItemsDemo.ViewModel;
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

namespace B2A.ToDoItemsDemo.View
{
    /// <summary>
    /// Interaction logic for ToDoItemView.xaml
    /// </summary>
    public partial class ToDoItemView : Window
    {
        public ToDoItemView(MainViewModel mainViewModel,Action RefreshOnChange)
        {
            InitializeComponent();
            this.DataContext = new ToDoItemViewModel(this, mainViewModel, RefreshOnChange);
        }
        public ToDoItemView(MainViewModel mainViewModel, ToDoItemDetailViewModel selectedItem,Action RefreshOnChange)
        {
            InitializeComponent();
            this.DataContext = new ToDoItemViewModel(this, mainViewModel, selectedItem, RefreshOnChange);
        }
    }
}
