using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson26_11_2018
{

    class Product
    {
        public Product(string name, int count, decimal price)
        {
            Name = name;
            Count = count;
            Price = price;
        }

        public string Name { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }

        public void ShowProduct()
        {
            Console.WriteLine("==========================");
            Console.WriteLine($"Product name {Name}");
            Console.WriteLine($"Product count {Count}");
            Console.WriteLine($"Price {Price}");
        }
    }
    class Controller
    {
        List<Product> products = new List<Product>() {
            new Product("Ps4",10,450.5m),
        new Product("Ps3",10,320.89m),
        new Product("Xbox",20,660.5m)
        };
        public void Run()
        {
            foreach (var item in products)
            {
                item.ShowProduct();
            }
            while (true)
            {
                DateTime current = DateTime.Now;
                Console.Write("Write name of Product ");
                string name = Console.ReadLine();
                Console.Write("Write count of product ");
                int count = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Product itemproduct = products.SingleOrDefault(x => x.Name == name);
                current = DateTime.Now;
                if (count < itemproduct.Count)
                {
                    itemproduct.Count -= count;
                }
                else
                {
                    Console.WriteLine("This count is not right");
                }
                //foreach (var item in products)
                //{
                //    item.ShowProduct();
                //}
                Console.WriteLine(); Console.Clear();
                using (StreamWriter strw = new StreamWriter(name + "_" + current.Millisecond + ".txt", true))
                {
                    strw.WriteLine("Name " + itemproduct.Name);
                    strw.WriteLine(" Count " + (itemproduct.Count));
                    strw.WriteLine(" Date " + current);
                }
                using (StreamReader strr = new StreamReader(name + "_" + current.Millisecond + ".txt", true))
                {
                    Console.WriteLine($"Product\n {strr.ReadToEnd()}");
                }
                foreach (var item in products)
                {
                    item.ShowProduct();
                }
            }

        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Controller cont = new Controller();
            cont.Run();
            //DirectoryInfo info = new DirectoryInfo(@"C:\Users\Jama_yw17\source\repos\Lesson26 11 2018");
            //if (info.Exists)
            //{
            //    Console.WriteLine("Okay");
            //    Console.WriteLine(info.Parent);
            //}
            //else
            //{
            //    Console.WriteLine("Not");
            //}


        }
    }
}
