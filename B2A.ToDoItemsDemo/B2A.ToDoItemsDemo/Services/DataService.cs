using B2A.ToDoItemsDemo.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
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


        public static List<ToDoItem> GetAllToDoItems()
        {
            List<ToDoItem> items = new List<ToDoItem>();
            //Fetch the data from database
            var connString = "User Id=postgres;Password=eF4icTwPruGO8HQI;Server=db.nspvkugakihrdvvlupef.supabase.co;Port=5432;Database=postgres";
            using var conn = new NpgsqlConnection(connString);

            conn.Open();

            using (var cmd = new NpgsqlCommand("SELECT * FROM todoitems", conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ToDoItem item = new ToDoItem();
                        //Ordinals
                        int idOrdinal = reader.GetOrdinal("id");
                        int nameOrdinal = reader.GetOrdinal("name");
                        int categoryOrdinal = reader.GetOrdinal("category");
                        int subCategoryOrdinal = reader.GetOrdinal("sub_category");
                        int percentDoneOrdinal = reader.GetOrdinal("percent_done");
                        int isDoneOrdinal = reader.GetOrdinal("is_done");
                        int dueDateOrdinal = reader.GetOrdinal("due_date");

                        //Actual Read
                        item.Id = reader.GetInt32(idOrdinal);
                        item.Name = reader.GetString(nameOrdinal);
                        item.Category = reader.GetString(categoryOrdinal);
                        item.SubCategory = reader.GetString(subCategoryOrdinal);
                        item.PercentDone = reader.GetInt32(percentDoneOrdinal);
                        item.IsDone = reader.GetBoolean(isDoneOrdinal);
                        item.DueDate = reader.GetDateTime(dueDateOrdinal);

                        items.Add(item);
                    }
                }
            }
            conn.Close();
            return items;
        }

        public static void AddToDoItem(ToDoItem toDoItem)
        {
            var connString = "User Id=postgres;Password=eF4icTwPruGO8HQI;Server=db.nspvkugakihrdvvlupef.supabase.co;Port=5432;Database=postgres";
            using var conn = new NpgsqlConnection(connString);

            conn.Open();

            using (var cmd = new NpgsqlCommand("INSERT INTO todoitems (name,category, sub_category, percent_done,due_date,is_done) VALUES (@name,@category, @sub_category, @percent_done, @due_date, @is_done)", conn))
            {
                cmd.Parameters.AddWithValue("name", toDoItem.Name);
                cmd.Parameters.AddWithValue("category", toDoItem.Category);
                cmd.Parameters.AddWithValue("sub_category", toDoItem.SubCategory);
                cmd.Parameters.AddWithValue("percent_done", toDoItem.PercentDone);
                cmd.Parameters.AddWithValue("due_date", toDoItem.DueDate);
                cmd.Parameters.AddWithValue("is_done", toDoItem.IsDone);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
        public static void UpdateToDoItem(ToDoItem toDoItem)
        {
            var connString = "User Id=postgres;Password=eF4icTwPruGO8HQI;Server=db.nspvkugakihrdvvlupef.supabase.co;Port=5432;Database=postgres";
            using var conn = new NpgsqlConnection(connString);

            conn.Open();

            using (var cmd = new NpgsqlCommand("Update todoitems Set name = @name ," +
                "category = @category, " +
                "sub_category = @sub_category, " +
                "percent_done= @percent_done," +
                "due_date = @due_date," +
                "is_done =@is_done where id = @id", conn))
            {
                cmd.Parameters.AddWithValue("id", toDoItem.Id);
                cmd.Parameters.AddWithValue("name", toDoItem.Name);
                cmd.Parameters.AddWithValue("category", toDoItem.Category);
                cmd.Parameters.AddWithValue("sub_category", toDoItem.SubCategory);
                cmd.Parameters.AddWithValue("percent_done", toDoItem.PercentDone);
                cmd.Parameters.AddWithValue("due_date", toDoItem.DueDate);
                cmd.Parameters.AddWithValue("is_done", toDoItem.IsDone);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public static void DleteToDoItem(int id)
        {
            var connString = "User Id=postgres;Password=eF4icTwPruGO8HQI;Server=db.nspvkugakihrdvvlupef.supabase.co;Port=5432;Database=postgres";
            using var conn = new NpgsqlConnection(connString);

            conn.Open();

            using (var cmd = new NpgsqlCommand("DELETE from todoitems where id = @id", conn))
            {
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
