using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBM_14Mar25_Day2
{
    internal class ADONET_Eg
    {

        static void Main()
        {

            SqlConnection _cn = new SqlConnection();
            #region Static ConStr Example
            //_cn.ConnectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=IBM14Mar25CWFDb;Integrated Security=True;"; 
            #endregion

            SqlConnectionStringBuilder _cnb = new SqlConnectionStringBuilder();

            _cnb.DataSource = @"(localdb)\projectmodels"; ;
            _cnb.InitialCatalog = "IBM14Mar25CWFDb";
            _cnb.IntegratedSecurity = true;

            _cn.ConnectionString = _cnb.ToString(); // Information regarding db Connection

            


            string choice = "";

            do
            {
                Console.Clear();

                Console.WriteLine("ADO.NET Intro using FoodItem \n\n\n0. Display All Food Items\n\n 1. Insert\n\n2. Update\n\n3. Delete\n\n4. Stored Proc call Get All FoodItems\n\n5. Get Food Item by ID \n\n6.Dataset Demo\n\n-1. Exit \n\n\n\n");
                Console.Write("Enter Choice:");
                choice = Console.ReadLine();

                if (choice == "0")
                {
                    Console.Clear();
                    ListAllFoodItems(_cn);

                }

                if (choice == "1")
                {
                    AddNewFoodItem(_cn);

                }
                if (choice == "2")
                {
                    UpdateFoodItem(_cn);

                }

                if (choice == "3")
                {
                    DeleteFoodItem(_cn );


                }
                if (choice == "4")
                {
                    CallStoredProcGetAllFoodItems(_cn);

                }
                if (choice == "5")
                {
                     CallStoredProcGetFoodItemByID(_cn);

                }

                if (choice == "6")
                {
                    DatasetEg(_cn);

                }


            } while (choice != "-1");


        }

        private static void DatasetEg(SqlConnection cn)
        {

            SqlDataAdapter _da = new SqlDataAdapter();

            _da.SelectCommand = new SqlCommand();
            _da.SelectCommand.CommandText = "select * from FoodItem ";
            _da.SelectCommand.Connection = cn;
            DataTable _dt = new DataTable();

            _da.Fill(_dt);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(@"FoodItemID  |FoodItemName        |Rate      |Vendor Name     ");
            foreach (DataRow _drow in _dt.Rows)
            {
                Console.WriteLine($"{_drow[0].ToString().PadLeft(12, ' ')} |{_drow[1].ToString().PadRight(25, ' ')}|{_drow[3].ToString().PadLeft(10, ' ')}|{_drow[4].ToString().PadRight(20, ' ')}");
            }

            // Row State management

            // RowState
            Console.WriteLine(_dt.Rows[0].RowState);

            DataRow _newRow = _dt.NewRow();
            Console.WriteLine(_dt.Rows[0]); // DataRowState.Detached

            _newRow["FoodItemName"] = "Item 1";
            _newRow[2] = "Desc ...";
            _newRow[3] = 1000;
            _newRow["VendorName"] = "";

            _newRow["CategoryID"] = 1;

            _dt.Rows.Add(_newRow); // Add new row 

            Console.WriteLine(_dt.Rows[0].RowState); // DataRowState.Added

            DataRow _oldFoodItem = _dt.Select($"FoodItemID={1}")[0];
            Console.WriteLine(_oldFoodItem.RowState); // DataRowState.Unchanged

            _oldFoodItem[1] = "New Food Item Name ....";
            Console.WriteLine(_oldFoodItem.RowState); // DataRowState.Modified

            DataRow _DelFoodItem = _dt.Select($"FoodItemID={6}")[0];

            _DelFoodItem.Delete();    // DataRowState.Deleted

            _da.InsertCommand = new SqlCommand("INSERT INTO [FoodItem]([FoodItemName],[FoodItemDesc],[Rate],[VendorName],[SubCategory],[CategoryID])VALUES(@FoodName,@FoodItmDesc,@Rate,@VendorName,@SubCategory,@CategoryID)", cn);

            _da.InsertCommand.Parameters.Add("@FoodName", SqlDbType.VarChar, 150).SourceColumn = "FoodItemName";
            _da.InsertCommand.Parameters.Add("@FoodItmDesc", SqlDbType.VarChar, 150).SourceColumn = "FoodItemDesc";
            _da.InsertCommand.Parameters.Add("@Rate", SqlDbType.Money).SourceColumn = "Rate";
            _da.InsertCommand.Parameters.Add("@VendorName", SqlDbType.VarChar, 100).SourceColumn = "VendorName";
            _da.InsertCommand.Parameters.Add("@SubCategory", SqlDbType.VarChar, 100).SourceColumn = "SubCategory";
            _da.InsertCommand.Parameters.Add("@CategoryID", SqlDbType.VarChar, 100).SourceColumn = "CategoryID";


            // Update Command 

            _da.UpdateCommand = new SqlCommand("UPDATE [dbo].[FoodItem]   SET [FoodItemName] = @FoodName,[FoodItemDesc] = @FoodItmDesc,[Rate] = @Rate,[VendorName] = @VendorName,[SubCategory] = @SubCategory,[CategoryID] = @CategoryID WHERE FoodItemID=@FID", cn);

            _da.UpdateCommand.Parameters.Add("@FoodName", SqlDbType.VarChar, 150).SourceColumn = "FoodItemName";
            _da.UpdateCommand.Parameters.Add("@FoodItmDesc", SqlDbType.VarChar, 150).SourceColumn = "FoodItemDesc";
            _da.UpdateCommand.Parameters.Add("@Rate", SqlDbType.Money).SourceColumn = "Rate";
            _da.UpdateCommand.Parameters.Add("@VendorName", SqlDbType.VarChar, 100).SourceColumn = "VendorName";
            _da.UpdateCommand.Parameters.Add("@SubCategory", SqlDbType.VarChar, 100).SourceColumn = "SubCategory";
            _da.UpdateCommand.Parameters.Add("@CategoryID", SqlDbType.VarChar, 100).SourceColumn = "CategoryID";
            _da.UpdateCommand.Parameters.Add("@FID", SqlDbType.VarChar, 100).SourceColumn = "FoodItemID";



            _da.DeleteCommand = new SqlCommand("delete [dbo].[FoodItem]   WHERE FoodItemID=@FID", cn);
            _da.DeleteCommand.Parameters.Add("@FID", SqlDbType.VarChar, 100).SourceColumn = "FoodItemID";


            _da.ContinueUpdateOnError = true;

            _da.Update(_dt);

            if (_dt.HasErrors == false) { 
                        Console.WriteLine("Database updated Successfully");

                        _dt.AcceptChanges();
                    }

            //_dt.DefaultView.RowFilter=""



        }

        private static void UpdateFoodItem(SqlConnection _cn)
        {
            
            Console.Clear();
            DisplayFoodItemsForEditorDelete(_cn);

         
            Console.Write("Enter Food Item Id to Edit:");
           string choice = Console.ReadLine();


            SqlCommand _cmd = new SqlCommand($"select * from FoodItem where FoodItemID = {choice}", _cn);

            _cn.Open();
          var _dr=  _cmd.ExecuteReader();

            if (!_dr.HasRows)
            {
                Console.WriteLine("Invalid Food Item ID, Record not found...");
                Console.WriteLine("Press any Key to Continue...");

                Console.ReadKey();
                return;
            }


            _dr.Read();

            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine($"{_dr.GetValue(0).ToString().PadLeft(12, ' ')} |{_dr.GetValue(1).ToString().PadRight(25, ' ')}|{_dr.GetValue(3).ToString().PadLeft(10, ' ')}|{_dr.GetValue(4).ToString().PadRight(20, ' ')}");


            _cn.Close();

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.Write("Enter New Values to Update \n\n\n ");

            Console.Write("Enter Food Item Name: ");
            string foodItemName = Console.ReadLine();

            Console.Write("Enter Food Item Description: ");
            string foodItemDesc = Console.ReadLine();

            Console.Write("Enter Rate: ");
            decimal rate = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Vendor Name: ");
            string vendorName = Console.ReadLine();

            Console.Write("Enter Sub Category: ");
            string subCategory = Console.ReadLine();

            Console.Write("Enter Category ID: ");
            int categoryID = Convert.ToInt32(Console.ReadLine());

             _cmd = new SqlCommand("UPDATE [dbo].[FoodItem]   SET [FoodItemName] = @FoodName,[FoodItemDesc] = @FoodItmDesc,[Rate] = @Rate,[VendorName] = @VendorName,[SubCategory] = @SubCategory,[CategoryID] = @CategoryID WHERE FoodItemID=@FID", _cn);

            _cmd.Parameters.Add("@FoodName", SqlDbType.VarChar, 150).Value = foodItemName;
            _cmd.Parameters.Add("@FoodItmDesc", SqlDbType.VarChar, 150).Value = foodItemDesc;
            _cmd.Parameters.Add("@Rate", SqlDbType.Money).Value = rate;
            _cmd.Parameters.Add("@VendorName", SqlDbType.VarChar, 100).Value = vendorName;
            _cmd.Parameters.Add("@SubCategory", SqlDbType.VarChar, 100).Value = subCategory;
            _cmd.Parameters.Add("@CategoryID", SqlDbType.VarChar, 100).Value = categoryID;
            _cmd.Parameters.Add("@FID", SqlDbType.Int).Value = choice;
            _cn.Open();


            if (_cmd.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("Updated Successfully  .....");
            }
            else
                Console.WriteLine("Edit Failed .....");

            _cn.Close();

            Console.WriteLine("Press any Key to Continue...");

            Console.ReadKey();



        }

        private static void DeleteFoodItem(SqlConnection _cn)
        {
            Console.Clear();
            DisplayFoodItemsForEditorDelete(_cn);




            Console.Write("Enter Food Item Id to Delete:");
            string choice = Console.ReadLine();


            SqlCommand _cmd = new SqlCommand($"select * from FoodItem where FoodItemID = {choice}", _cn);

            _cn.Open();
            var _dr = _cmd.ExecuteReader();
            if (!_dr.HasRows)
            {
                Console.WriteLine("Invalid Food Item ID, Record not found...");
                Console.WriteLine("Press any Key to Continue...");

                Console.ReadKey();
                return;
            }


            _dr.Read();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{_dr.GetValue(0).ToString().PadLeft(12, ' ')} |{_dr.GetValue(1).ToString().PadRight(25, ' ')}|{_dr.GetValue(3).ToString().PadLeft(10, ' ')}|{_dr.GetValue(4).ToString().PadRight(20, ' ')}");


            _cn.Close();

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.Write("Are you Sure Deleted Above Record \n\n\n (Y/N) ");

           
            string confirm = Console.ReadLine();

            if (confirm.ToUpper()!="Y")
            {

                return;

            }

            _cmd = new SqlCommand("delete [dbo].[FoodItem] WHERE FoodItemID=@FID", _cn);

           
            _cmd.Parameters.Add("@FID", SqlDbType.Int).Value = choice;
            _cn.Open();


            if (_cmd.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("Deleted Successfully  .....");
            }
            else
                Console.WriteLine("Delete Failed .....");

            _cn.Close();

            Console.WriteLine("Press any Key to Continue...");

            Console.ReadKey();



        }


        private static void CallStoredProcGetFoodItemByID(SqlConnection _cn)
        {
            Console.Clear();
           




            Console.Write("Enter Food Item Id :");
            string choice = Console.ReadLine();


            SqlCommand _cmd = new SqlCommand($"GetFoodItemNameByID", _cn);
            _cmd.CommandType= CommandType.StoredProcedure;
            _cmd.Parameters.Add("@fooditmID", SqlDbType.Int).Value = choice;
            _cmd.Parameters.Add("@foodName", SqlDbType.VarChar,150).Direction= ParameterDirection.Output;

            _cn.Open();
            var _dr = _cmd.ExecuteNonQuery();
            if (_cmd.Parameters["@foodName"].Value==null )
            {
                Console.WriteLine("Invalid Food Item ID, Record not found...");
                Console.WriteLine("Press any Key to Continue...");

                Console.ReadKey();
                return;
            }


            _cn.Close();

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"Food Item Name :{_cmd.Parameters["@foodName"].Value}" );
                Console.ForegroundColor = ConsoleColor.Blue;


         

            Console.WriteLine("Press any Key to Continue...");

            Console.ReadKey();



        }



        private static void CallStoredProcGetAllFoodItems(SqlConnection _cn)
        {
            Console.Clear();
            SqlCommand _cmd = new SqlCommand($"GetAllFoodItems", _cn);
            _cmd.CommandType = CommandType.StoredProcedure;
        

            _cn.Open();
            var _dr = _cmd.ExecuteReader();
            if (!_dr.HasRows)
            {
                Console.WriteLine(" Record(s) not found...");
                Console.WriteLine("Press any Key to Continue...");

                Console.ReadKey();
                return;
            }




            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(@"FoodItemID  |FoodItemName        |Rate      |Vendor Name     ");
                Console.ForegroundColor = ConsoleColor.Blue;
                while (_dr.Read())
                {
                    Console.WriteLine($"{_dr.GetValue(0).ToString().PadLeft(12, ' ')} |{_dr.GetValue(1).ToString().PadRight(25, ' ')}|{_dr.GetValue(3).ToString().PadLeft(10, ' ')}|{_dr.GetValue(4).ToString().PadRight(20, ' ')}");
                }
           

            _cn.Close();

            Console.WriteLine("Press any Key to Continue...");

            Console.ReadKey();



        }


        private static void AddNewFoodItem(SqlConnection _cn)
        {
            Console.Write("Enter Food Item Name: ");
            string foodItemName = Console.ReadLine();

            Console.Write("Enter Food Item Description: ");
            string foodItemDesc = Console.ReadLine();

            Console.Write("Enter Rate: ");
            decimal rate = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Vendor Name: ");
            string vendorName = Console.ReadLine();

            Console.Write("Enter Sub Category: ");
            string subCategory = Console.ReadLine();

            Console.Write("Enter Category ID: ");
            int categoryID = Convert.ToInt32(Console.ReadLine());

            SqlCommand _cmd = new SqlCommand("INSERT INTO [FoodItem]([FoodItemName],[FoodItemDesc],[Rate],[VendorName],[SubCategory],[CategoryID])VALUES(@FoodName,@FoodItmDesc,@Rate,@VendorName,@SubCategory,@CategoryID)", _cn);

            _cmd.Parameters.Add("@FoodName", SqlDbType.VarChar,150).Value=foodItemName;
            _cmd.Parameters.Add("@FoodItmDesc", SqlDbType.VarChar, 150).Value = foodItemDesc;
            _cmd.Parameters.Add("@Rate", SqlDbType.Money).Value = rate;
            _cmd.Parameters.Add("@VendorName", SqlDbType.VarChar, 100).Value = vendorName;
            _cmd.Parameters.Add("@SubCategory", SqlDbType.VarChar, 100).Value = subCategory;
            _cmd.Parameters.Add("@CategoryID", SqlDbType.VarChar, 100).Value = categoryID;

            _cn.Open();

            
            if (_cmd.ExecuteNonQuery()>0)
            {
                Console.WriteLine(  "Successfully Inserted .....");
            }
            else
                Console.WriteLine("Insert Failed .....");

            _cn.Close();

            Console.WriteLine("Press any Key to Continue...");

            Console.ReadKey();
        }

        private static void ListAllFoodItems(SqlConnection _cn)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.Connection = _cn;
            _cmd.CommandType= CommandType.Text;
            _cmd.CommandText = "select * from fooditem"; ;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(@"FoodItemID  |FoodItemName        |Food Item Description         |Rate      |Vendor Name         |Sub Category   |Category       ");
            _cn.Open();

          SqlDataReader _dr =  _cmd.ExecuteReader();
            if (_dr.HasRows)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                while (_dr.Read())
                {
                    Console.WriteLine($"{_dr.GetValue(0).ToString().PadLeft(12, ' ')} |{_dr.GetValue(1).ToString().PadRight(25, ' ')}|{_dr.GetValue(2).ToString().PadRight(35, ' ')}|{_dr.GetValue(3).ToString().PadLeft(10, ' ')}|{_dr.GetValue(4).ToString().PadRight(20, ' ')}|{_dr.GetValue(5).ToString().PadRight(15, ' ')}|{_dr.GetValue(6).ToString().PadRight(15, ' ')}");
                }
            }
            else
            {

                Console.WriteLine(  "Record(s) Not Found");
            }
            _dr.Close();

            _cn.Close();



            Console.WriteLine("Press any Key to Continue...");

            Console.ReadKey();
         


        }



        private static void DisplayFoodItemsForEditorDelete(SqlConnection _cn)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.Connection = _cn;
            _cmd.CommandType = CommandType.Text;
            _cmd.CommandText = "select * from fooditem"; ;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(@"FoodItemID  |FoodItemName        |Rate      |Vendor Name     ");
            _cn.Open();

            SqlDataReader _dr = _cmd.ExecuteReader();
            if (_dr.HasRows)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                while (_dr.Read())
                {
                    Console.WriteLine($"{_dr.GetValue(0).ToString().PadLeft(12, ' ')} |{_dr.GetValue(1).ToString().PadRight(25, ' ')}|{_dr.GetValue(3).ToString().PadLeft(10, ' ')}|{_dr.GetValue(4).ToString().PadRight(20, ' ')}");
                }
            }
           
            _dr.Close();

            _cn.Close();

        }
    }
}
