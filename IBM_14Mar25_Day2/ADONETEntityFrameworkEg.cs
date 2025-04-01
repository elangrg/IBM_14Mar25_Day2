using IBM_14Mar25_Day2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBM_14Mar25_Day2
{
    internal class ADONETEntityFrameworkEg
    {
        static void Main()
        {

            string choice = "";

            Models.IBM14Mar25CWFDbEntities _db = new Models.IBM14Mar25CWFDbEntities();



            do
            {
                Console.Clear();

                Console.WriteLine("ADO.NET Entity Framework Intro using FoodItem \n\n\n0. Display All Food Items\n\n 1. Insert\n\n2. Update\n\n3. Delete\n\n4. Stored Proc call Get All FoodItems\n\n5. Get Food Item by ID \n\n6.Dataset Demo\n\n-1. Exit \n\n\n\n");
                Console.Write("Enter Choice:");
                choice = Console.ReadLine();

                if (choice == "0")
                {
                    Console.Clear();
                   ListAllFoodItems(_db);

                }

                if (choice == "1")
                {
                   AddNewFoodItem(_db);

                }
                if (choice == "2")
                {
                   UpdateFoodItem(_db);

                }

                if (choice == "3")
                {
                    DeleteFoodItem(_db);


                }
                if (choice == "4")
                {
                   CallStoredProcGetAllFoodItems(_db);

                }
                if (choice == "5")
                {
                   CallStoredProcGetFoodItemByID(_db);

                }

                if (choice == "6")
                {
                   // DatasetEg(_cn);

                }


            } while (choice != "-1");


        }

        private static void CallStoredProcGetAllFoodItems(IBM14Mar25CWFDbEntities db)
        {
              Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(@"FoodItemID  |FoodItemName        |Rate      |Vendor Name     ");
           
              Console.ForegroundColor = ConsoleColor.Blue;


           foreach (var fooditm in db.GetFoodItems().ToList())
            {
                Console.WriteLine($"{fooditm.FoodItemName.PadLeft(12, ' ')} |{fooditm.FoodItemDesc.PadRight(25, ' ')}|{fooditm.Rate.ToString().PadLeft(10, ' ')}|{fooditm.VendorName.PadRight(20, ' ')}|    ");
            }


        }

        private static void CallStoredProcGetFoodItemByID(IBM14Mar25CWFDbEntities db)
        {
            ObjectParameter prm = new ObjectParameter("foodName", "");
            db.GetFoodItemNameByID(1, prm);
            Console.WriteLine(  prm.Value);
        }

        private static void DeleteFoodItem(IBM14Mar25CWFDbEntities db)
        {
            Console.Clear();
            DisplayFoodItemsForEditorDelete(db);


            Console.Write("Enter Food Item Id to Delete:");
            string choice = Console.ReadLine();

            var fooditm = db.FoodItems.Find(choice);

            if (fooditm == null)
            {
                Console.WriteLine("Record not found");
                return;
            }
            Console.WriteLine(db.Entry(fooditm).State);

            Console.WriteLine($"{fooditm.FoodItemName.PadLeft(12, ' ')} |{fooditm.FoodItemDesc.PadRight(25, ' ')}|{fooditm.Rate.ToString().PadLeft(10, ' ')}|{fooditm.VendorName.PadRight(20, ' ')}|{fooditm.Category.CategoryName}    ");

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.Write("Are you Sure Deleted Above Record \n\n\n (Y/N) ");


            string confirm = Console.ReadLine();

            if (confirm.ToUpper() != "Y")
            {

                return;

            }
            db.FoodItems.Remove(fooditm);

            db.SaveChanges();
        }

        private static void UpdateFoodItem(IBM14Mar25CWFDbEntities db)
        {
            Console.Clear();
            DisplayFoodItemsForEditorDelete(db);


            Console.Write("Enter Food Item Id to Edit:");
            string choice = Console.ReadLine();

            var fooditm = db.FoodItems.Find(int.Parse(   choice));
       
            if (fooditm==null)
            {
                Console.WriteLine(  "Record not found");
                return;
            }
            Console.WriteLine(db.Entry(fooditm).State);

            Console.WriteLine($"{fooditm.FoodItemName.PadLeft(12, ' ')} |{fooditm.FoodItemDesc.PadRight(25, ' ')}|{fooditm.Rate.ToString().PadLeft(10, ' ')}|{fooditm.VendorName.PadRight(20, ' ')}|{fooditm.Category.CategoryName}    ");

            Models.FoodItem objFI = fooditm;

            Console.Write("Enter Food Item Name: ");
            objFI.FoodItemName = Console.ReadLine();

            Console.Write("Enter Food Item Description: ");
            objFI.FoodItemDesc = Console.ReadLine();

            Console.Write("Enter Rate: ");
            objFI.Rate = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Vendor Name: ");
            objFI.VendorName = Console.ReadLine();

            Console.Write("Enter Sub Category: ");
            objFI.SubCategory = Console.ReadLine();

            Console.Write("Enter Category ID: ");
            objFI.CategoryID = Convert.ToInt32(Console.ReadLine());
          
            Console.WriteLine(db.Entry(objFI).State);

            db.SaveChanges();

        }

        private static void AddNewFoodItem(IBM14Mar25CWFDbEntities _db)
        {
            Models.FoodItem objFI = new FoodItem();

            Console.Write("Enter Food Item Name: ");
            objFI.FoodItemName = Console.ReadLine();

            Console.Write("Enter Food Item Description: ");
            objFI.FoodItemDesc = Console.ReadLine();

            Console.Write("Enter Rate: ");
            objFI.Rate = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Vendor Name: ");
            objFI.VendorName = Console.ReadLine();

            Console.Write("Enter Sub Category: ");
            objFI.SubCategory = Console.ReadLine();

            Console.Write("Enter Category ID: ");
            objFI.CategoryID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(_db.Entry(objFI).State);   
            _db.FoodItems.Add(objFI);
            Console.WriteLine(_db.Entry(objFI).State);

            _db.SaveChanges();

        }

        private static void ListAllFoodItems(IBM14Mar25CWFDbEntities _db)
        {

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(@"FoodItemID  |FoodItemName        |Rate      |Vendor Name     ");
           
                Console.ForegroundColor = ConsoleColor.Blue;


           foreach (var fooditm in _db.FoodItems.ToList())
            {
                Console.WriteLine($"{fooditm.FoodItemName.PadLeft(12, ' ')} |{fooditm.FoodItemDesc.PadRight(25, ' ')}|{fooditm.Rate.ToString().PadLeft(10, ' ')}|{fooditm.VendorName.PadRight(20, ' ')}|{fooditm.Category.CategoryName}    ");
            }


        }





        private static void DisplayFoodItemsForEditorDelete(Models.IBM14Mar25CWFDbEntities  _db)
        {
           

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(@"FoodItemID  |FoodItemName        |Rate      |Vendor Name     ");
        

           
                Console.ForegroundColor = ConsoleColor.Blue;
            foreach (var fooditm in _db.FoodItems)
            {
                Console.WriteLine($"{fooditm.FoodItemName.PadLeft(12, ' ')} |{fooditm.FoodItemDesc.PadRight(25, ' ')}|{fooditm.Rate.ToString().PadLeft(10, ' ')}|{fooditm.VendorName.PadRight(20, ' ')}|{fooditm.Category.CategoryName}    ");
            }
          
            

        }
    }
}
