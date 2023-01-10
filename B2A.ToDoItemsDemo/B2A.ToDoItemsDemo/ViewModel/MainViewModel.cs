using B2A.ToDoItemsDemo.Model;
using B2A.ToDoItemsDemo.Services;
using B2A.ToDoItemsDemo.View;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace B2A.ToDoItemsDemo.ViewModel
{
    public class MainViewModel:BaseViewModel
    {
        #region Properties
        private ObservableCollection<ToDoItemDetailViewModel> _toDoItemList;
        public ObservableCollection<ToDoItemDetailViewModel> ToDoItemList
        {
            get
            {
                return _toDoItemList;
            }
            set
            {
                _toDoItemList = value;
                NotifyPropertyChanged();
            }
        }

        private ToDoItemDetailViewModel _selectedToDoItem;
        public ToDoItemDetailViewModel SelectedToDoItem
        {
            get
            {
                return _selectedToDoItem;
            }
            set
            {
                _selectedToDoItem = value;
                EditCommand.RaiseCanExecuteChanged();
                DeleteCommand.RaiseCanExecuteChanged();
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region Commands
        private RelayCommand _addToDoItemCommand;
        public RelayCommand AddToDoItemCommand
        {
            get
            {
                if(_addToDoItemCommand == null)
                {
                    _addToDoItemCommand = new RelayCommand(ShowToDoItemDialog, true);
                }
                return _addToDoItemCommand;
            }
        }

        private RelayCommand _editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                if (_editCommand == null)
                {
                    _editCommand = new RelayCommand(EditSelectedItem, CanEdit);
                }
                return _editCommand;
            }
        }

        private RelayCommand _deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand(DeleteSelectedItem, CanDelete);
                }
                return _deleteCommand;
            }
        }

        #endregion

        #region Constructors
        public MainViewModel()
        {
            ToDoItemList = new ObservableCollection<ToDoItemDetailViewModel>();

            LoadAllGetItems();
        }

        
        #endregion

        #region Methods
        private void ShowToDoItemDialog()
        {
            ToDoItemView toDoItemView = new ToDoItemView(this, ReloadOnRefresh);
            toDoItemView.ShowDialog();
        }

        private bool CanDelete()
        {
            //if (SelectedToDoItem == null)
            //    return false;
            //else
            //    return true;

            return SelectedToDoItem != null; 
        }

        private void DeleteSelectedItem()
        {

            string message = "Are you sure you want to delete the selected item?";
            MessageBoxButton button = MessageBoxButton.YesNo;
            string caption = "B2A TODO Items";

            MessageBoxResult messageBoxResult = MessageBox.Show(message, caption, button,MessageBoxImage.Warning,MessageBoxResult.No);

            if(messageBoxResult == MessageBoxResult.Yes)
            {
                DataService.DleteToDoItem(SelectedToDoItem.Id);
                LoadAllGetItems();
            }
        }
        private bool CanEdit()
        {
            return SelectedToDoItem != null;
        }

        private void EditSelectedItem()
        {
            ToDoItemView toDoItemView = new ToDoItemView(this,SelectedToDoItem, ReloadOnRefresh);
            toDoItemView.ShowDialog();
        }

        public void ReloadOnRefresh()
        {
            LoadAllGetItems();
        }
        private void LoadAllGetItems()
        {
            ToDoItemList.Clear();

            List<ToDoItem> items = DataService.GetAllToDoItems();

            foreach (var item in items)
            {
                ToDoItemDetailViewModel itemViewModel = new ToDoItemDetailViewModel();
                itemViewModel.Id = item.Id;
                itemViewModel.Name = item.Name;
                itemViewModel.PercentDone = item.PercentDone;
                itemViewModel.DueDate = item.DueDate;
                itemViewModel.Category = item.Category;
                itemViewModel.SubCategory = item.SubCategory;
                itemViewModel.IsDone = item.IsDone;

                ToDoItemList.Add(itemViewModel);
            }
        }
        #endregion

        #region Cleanup

        #endregion
    }
}
