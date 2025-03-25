using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBM_14Mar25_Day2
{
    internal class ConstructorEg
    {
        static void Main()
        {


            // Static Ctor Demo

            singletonEg obj = singletonEg.GetObject ();

            Console.WriteLine( StaticCtor.msg.Length  );  

        //    AUDIProduct prd0 = new AUDIProduct();


        //Product prd= new Product();

        //    Product prd1 = new Product(1000, "BMW");

        //    Product prd2 = new Product(1001, "BMW","Car");




        }
    }

    class AUDIProduct:ProductEg
    {
        public AUDIProduct():base(1001,"AUDI X7")
        {
                
        }


    }

    class ProductEg
    {
        public int ProductId;
        public string Name;
        public string Description;
        public string Category;
        public int Qty;

        public ProductEg()
        {
            this.ProductId = 0;
            this.Qty = 100;
            this.Category = "NA";
            this.Description = string.Empty;
            this.Name = string.Empty;
        }

        public ProductEg(  int ProductId,string Name,string Description,
         string Category,int Qty  ) 
        {
            this.ProductId =ProductId;
            this.Qty = Qty;
            this.Category = Category;
            this.Description = Description;
            this.Name = Name;
            
        }


        public ProductEg(int ProductId, string Name):this()
        {
            this.ProductId = ProductId;
            this.Name = Name;
        }
        public ProductEg(int _ProductId, string _Name, string _Category) :this(_ProductId,_Name)
        {
            
            Category = _Category;
           
        }

    }

    class singletonEg
    {
        static singletonEg obj =null;

       private singletonEg()
        {
                
        }

        public static singletonEg  GetObject()
        { 
            if (obj == null)
                    obj = new singletonEg();

            return obj;
        
        }



    }

    class StaticCtor
    {

        public static  string msg = null;
        static StaticCtor()
        {
            msg = "Hello ";


        }

        public StaticCtor()
        {
           


        }



    }
    

}
