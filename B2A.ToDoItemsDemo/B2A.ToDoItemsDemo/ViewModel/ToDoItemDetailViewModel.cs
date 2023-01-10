using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2A.ToDoItemsDemo.ViewModel
{
    public class ToDoItemDetailViewModel: BaseViewModel
    {
        public int Id { get; set; }

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
        private int _percentDone;
        public int PercentDone
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

        private string _category;
        public string Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
                NotifyPropertyChanged();
            }
        }
        private string _subCategory;
        public string SubCategory
        {
            get
            {
                return _subCategory;
            }
            set
            {
                _subCategory = value;
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
    }
}
