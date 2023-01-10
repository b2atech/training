using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2A.ToDoItemsDemo.Model
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public bool IsDone{ get; set; }

        public int PercentDone{ get; set; }

        public DateTime DueDate { get; set; }
    }
}
