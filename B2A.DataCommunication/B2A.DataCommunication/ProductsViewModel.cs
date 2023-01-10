using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace B2A.DataCommunication
{
    public class ProductsViewModel : BaseViewModel
    {
        #region Properties
        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get
            {
                return _products;
            }
            set
            {
                _products = value;
                NotifyPropertyChanged();
            }

        }
        #endregion
        #region Relay Commands
        private RelayCommand _showAddProductCommand;
        public RelayCommand ShowAddProductCommand
        {
            get
            {
                if (_showAddProductCommand == null)
                {
                    _showAddProductCommand = new RelayCommand(ShowAddProduct, true);
                }

                return _showAddProductCommand;
            }
            
        }

        #endregion

        #region Constructor
        public ProductsViewModel()
        {
            _products = new ObservableCollection<Product>();
            
        }
        #endregion

        #region Method
        private void ShowAddProduct()
        {
            ProductView product = new ProductView(this);
            product.ShowDialog();
        }
        #endregion

    }
}
