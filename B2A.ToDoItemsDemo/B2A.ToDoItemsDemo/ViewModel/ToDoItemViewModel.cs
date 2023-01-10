using B2A.ToDoItemsDemo.Model;
using B2A.ToDoItemsDemo.Services;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace B2A.ToDoItemsDemo.ViewModel
{
    public class ToDoItemViewModel:BaseViewModel
    {

        #region Properties
        private bool isInEditMode;
        private ToDoItemDetailViewModel _selectedItem;
        private Window currentWindow;
        private MainViewModel mainViewModel;
        private List<string> _categoryList;
        public List<string> CategoryList
        {
            get 
            { 
                return _categoryList; 
            } 
            set 
            { 
                _categoryList = value; 
            }
        }

        private ObservableCollection<string> _subCategorieList;

        public ObservableCollection<string> SubCategoryList
        {
            get
            {
                return _subCategorieList;
            }
            set
            {
                _subCategorieList = value;
            }
        }

        private string _selectedSubCategory;
        public string SelectedSubCategory
        {
            get
            {
                return _selectedSubCategory;
            }
            set
            {
                _selectedSubCategory = value;
                NotifyPropertyChanged();
            }
        }

        private string _selectedCategory;
        public string SelectedCategory
        {
            get
            {
                return _selectedCategory;
            }
            set
            {
                _selectedCategory = value;
                NotifyPropertyChanged();
                LoadSubCategories();
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyPropertyChanged();
            }
        }

        private bool _isDone;
        public bool IsDone
        {
            get
            {
                return _isDone;
            }
            set
            {
                _isDone = value;
                NotifyPropertyChanged();
            }
        }

        private string _addUpdateButtonTitle;
        public string AddUpdateButtonTitle
        {
            get
            {
                return _addUpdateButtonTitle;
            }
            set
            {
                _addUpdateButtonTitle = value;
                NotifyPropertyChanged();
            }
        }

        private int? _percentDone;
        public int? PercentDone
        {
            get
            {
                return _percentDone;
            }
            set
            {
                _percentDone = value;
                NotifyPropertyChanged();
            }
        }

        private DateTime _dueDate;
        public DateTime DueDate
        {
            get
            {
                return _dueDate;
            }
            set
            {
                _dueDate = value;
                NotifyPropertyChanged();
            }
        }

        

        #endregion

        #region Commands
        private RelayCommand _clearCommand;
        public RelayCommand ClearCommand
        {
            get
            {
                if(_clearCommand == null)
                {
                    _clearCommand = new RelayCommand(Clear, true);
                }
                return _clearCommand;
            }
        }
        private RelayCommand _saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(Save, true);
                }
                return _saveCommand;
            }
        }

        private RelayCommand _cancelCommand;
        public RelayCommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                {
                    _cancelCommand = new RelayCommand(Cancel, true);
                }
                return _cancelCommand;
            }
        }

        
        #endregion

        #region Constructors
        public ToDoItemViewModel(Window window, MainViewModel mainViewModel)
        {
            isInEditMode = false;
            AddUpdateButtonTitle = "Add";
            this.mainViewModel = mainViewModel;
            currentWindow = window;
            this.DueDate = DateTime.Now.AddDays(1);
             
            //1.
            //List<string> categories = DataService.GetAllCategories();
            //CategoryList = new ObservableCollection<string>();

            //foreach (var item in categories)
            //{
            //    CategoryList.Add(item);
            //}

            //2.
            //List<string> categories = DataService.GetAllCategories();
            //CategoryList = new ObservableCollection<string>(categories);

            //3.
            //CategoryList = new ObservableCollection<string>(DataService.GetAllCategories());
            CategoryList = DataService.GetAllCategories();
            SubCategoryList = new ObservableCollection<string>();
        }
        public ToDoItemViewModel(Window window, MainViewModel mainViewModel, ToDoItemDetailViewModel selectedItem)
            :this(window,mainViewModel)
        {
            

             _selectedItem = selectedItem;
            
            this.Name = _selectedItem.Name;
            this.SelectedCategory = _selectedItem.Category;
            this.SelectedSubCategory = _selectedItem.SubCategory;
            this.IsDone = _selectedItem.IsDone;

            isInEditMode = true;
            AddUpdateButtonTitle = "Update";
        }
        #endregion

        #region Methods
        private void LoadSubCategories()
        {
            SubCategoryList.Clear();
            List<string> subCategories = DataService.GetAllSubCategories(SelectedCategory);
            
            foreach (var item in subCategories)
            {
                SubCategoryList.Add(item);
            }
        }

        private void Cancel()
        {
            currentWindow.Close();
        }

        private void Save()
        {
            if(isInEditMode == true)
            {
                UpdateCurrentItem();
            }
            else
            {
                AddNewItem();
            }
            currentWindow.Close();
        }

        private void AddNewItem()
        {
            ToDoItemDetailViewModel toDoItem = new ToDoItemDetailViewModel();

            toDoItem.Name = this.Name;
            toDoItem.Category = SelectedCategory;
            toDoItem.SubCategory = SelectedSubCategory;
            toDoItem.IsDone = IsDone;
            toDoItem.DueDate = this.DueDate;
            
            //if (this.PercentDone.HasValue == true)
            //{
            //    toDoItem.PercentDone = this.PercentDone.Value;
            //}
            //else
            //{
            //    toDoItem.PercentDone = 0;
            //}
            
            toDoItem.PercentDone = PercentDone.HasValue? PercentDone.Value : 0;

            mainViewModel.ToDoItemList.Add(toDoItem);
        }

        private void UpdateCurrentItem()
        {
            _selectedItem.Name = this.Name;
            _selectedItem.Category = SelectedCategory;
            _selectedItem.SubCategory = SelectedSubCategory;
            _selectedItem.IsDone = IsDone;
        }

        private void Clear()
        {
            this.Name = string.Empty;
            this.SelectedCategory = null;
            this.SelectedSubCategory = string.Empty;
            this.IsDone = false;
        }
        #endregion

        #region Cleanup

        #endregion

    }
}
