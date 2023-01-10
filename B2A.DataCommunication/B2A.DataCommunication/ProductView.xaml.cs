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

namespace B2A.DataCommunication
{
    /// <summary>
    /// Interaction logic for ProductView.xaml
    /// </summary>
    public partial class ProductView : Window
    {
        public ProductView(ProductsViewModel productsViewModel)
        {
            InitializeComponent();
            
            ProductViewModel productViewModel = new ProductViewModel(productsViewModel,this);
            this.DataContext = productViewModel;
            
        }
    }
}
