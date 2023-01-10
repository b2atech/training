using B2A.ToDoItemsDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2A.ToDoItemsDemo.Services
{
    public class DataService
    {
        private static List<SubCategory> subCategories = new List<SubCategory>() 
        { 
            new SubCategory(){Category = "Persdonal", Name="Health"},
            new SubCategory(){Category = "Personal", Name="Education"},
            new SubCategory(){Category = "Official", Name="Meetings"},
            new SubCategory(){Category = "Official", Name="Trainings"},
            new SubCategory(){Category = "Mis", Name="Timepass"},
        };

        public static List<string> GetAllCategories()
        { 
            return subCategories.Select(c => c.Category).Distinct().ToList();
        }

        public static List<string> GetAllSubCategories(string selectedCategory)
        {
            //List<string> result = new List<string>();

            // 1. Simple For Loop
            //for (int i = 0; i < subCategories.Count; i++)
            //{
            //    var subCategory = subCategories[i];

            //    if (subCategory.Category == selectedCategory)
            //    {
            //        result.Add(subCategory.Name);
            //    }
            //}

            // 2. Better For each Loop
            //foreach (SubCategory subCategory in subCategories)
            //{
            //    if (subCategory.Category == selectedCategory)
            //    {
            //        result.Add(subCategory.Name);
            //    }
            //}

            //return result;

            // 3. LINQ
            //return (from sc in subCategories
            //          where sc.Category == selectedCategory
            //          select sc.Name).ToList();
           
            // 4. Lambda

            return subCategories.Where(x=> x.Category == selectedCategory).Select(x=>x.Name).ToList();

        }
    }
}
