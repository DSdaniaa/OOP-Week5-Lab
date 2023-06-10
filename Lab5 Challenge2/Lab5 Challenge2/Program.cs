using Lab5_Challenge2.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab5_Challenge2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<product> products = new List<product>();
            List<credentials> users = new List<credentials>();
            string path = "C:\\OOP\\credentials.txt";
            int option;
            string flag,name;
            char choice;
            do
            {
                readData(path, users);
                Console.Clear();
                option = menu();
                Console.Clear();
                if (option == 1)
                {
                    Console.WriteLine("Enter UserName: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    string p = Console.ReadLine();
                    flag=signIn(n, p, users);
                    if (flag == "admin")
                    {
                        do
                        {
                            choice = adminMenu();
                            if (choice == '1')
                            {
                                products.Add(addProduct());

                            }
                            else if (choice == '2')
                            {
                                viewProducts(products);

                            }
                            else if (choice == '3')
                            {
                                name = findProduct(products);
                                Console.Clear();
                                Console.WriteLine("Product with the Highest Unit Price is: {0}", name);
                                Console.ReadKey();
                            }
                            else if (choice == '4')
                            {
                                tax(products);
                            }
                            else if (choice == '5')
                            {
                                toBeOrdered(products);
                            }

                        } while (choice != '6');
                    }
                    else if (flag == "customer")
                    {
                        customer person = new customer();
                        do
                        {
                            choice = customerMenu();
                            if (choice == '1')
                            {
                                customerViewProducts(products);
                            }
                            else if (choice == '2')
                            {
                                Console.Clear();
                                Console.Write("Enter the name of the product: ");
                                name = Console.ReadLine();
                                buyProduct(name, products,person);
                            }
                            else if (choice == '3')
                            {
                                GenerateInvoice(person);
                            }


                        } while (choice != '4');

                    }
                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter New UserName: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter New Password: ");
                    string p = Console.ReadLine();
                    Console.WriteLine("Enter as (admin) or (customer): ");
                    string a= Console.ReadLine();
                    signUp(path, n, p,a);
                }
            }
            while (option !=3);
        }


        static int menu()
        {
            int option;
            Console.WriteLine("1. SignIn");
            Console.WriteLine("2. SignUp");
            Console.WriteLine("3. Exit");
            Console.Write("Enter Option: ");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        static char adminMenu()
        {
            Console.Clear();
            char choice;
            Console.WriteLine("1. Add a product ");
            Console.WriteLine("2. view products");
            Console.WriteLine("3. Find Product with the Highest Unit Price");
            Console.WriteLine("4. View Sales Tax of All Products. ");
            Console.WriteLine("5. Products to be Ordered. (less than threshold)");
            Console.WriteLine("6. Exit");
            Console.Write("Enter Option: ");
            choice = char.Parse(Console.ReadLine());
            return choice;

        }
        static char customerMenu()
        {
            Console.Clear();
            char choice;
            Console.WriteLine("1.View all the products");
            Console.WriteLine("2.Buy the products");
            Console.WriteLine("3.Generate invoice");
            Console.WriteLine("4.Exit");
            Console.Write("Enter Option: ");
            choice = char.Parse(Console.ReadLine());
            return choice;
        }
        static product addProduct()
        {
            Console.Clear();
            Console.Write("Enter the name: ");
            string name = Console.ReadLine();
            Console.Write("Enter the category: ");
            string category = Console.ReadLine();
            Console.Write("Enter the price: ");
            float price = float.Parse(Console.ReadLine());
            Console.Write("Enter the stock Quantity: ");
            int stockQuantity = int.Parse(Console.ReadLine());
            Console.Write("Enter the Minimum Stock Quantity: ");
            int minStockQuantity = int.Parse(Console.ReadLine());
            product s1 = new product(name,category,price,stockQuantity,minStockQuantity);
            return s1;
        }
        static void buyProduct(string name, List<product> s,customer p)
        {
            for(int i = 0; i < s.Count(); i++)
            {
                if (name == s[i].name)
                {
                    p.addProduct(s[i]);
                }
            }
        }
        static void viewProducts(List<product> s)
        {
            Console.Clear();
            for (int i = 0; i < s.Count; i++)
            {
                Console.WriteLine("Name: {0} Category: {1} Price: {2} Stock Quantity: {3} Minimum Stock Quantity: {4}", s[i].name, s[i].category, s[i].price, s[i].stockQuantity, s[i].minStockQuantity);
            }
            Console.WriteLine("press any key to continue...");
            Console.ReadKey();
        }
        static void GenerateInvoice(customer s)
        {
            Console.Clear();
            float price;
            price = s.calculatePrice();
            Console.WriteLine("Total Price: " + price);
            Console.WriteLine("press any key to continue...");
            Console.ReadKey();
        }
        static void customerViewProducts(List<product> s)
        {
            Console.Clear();
            for (int i = 0; i < s.Count; i++)
            {
                Console.WriteLine("Name: {0} Category: {1} Price: {2} ", s[i].name, s[i].category, s[i].price);
            }
            Console.WriteLine("press any key to continue...");
            Console.ReadKey();
        }
        static string findProduct(List<product> s)
        {
            int temp = -1;
            Console.Clear();
            for (int i = 1; i < s.Count; i++)
            {
                if (s[i - 1].price > s[i].price)
                {
                    temp = i - 1;
                }

            }
            return s[temp].name;
        }
        static void tax(List<product> s)
        {
            Console.Clear();
            for (int i = 0; i < s.Count; i++)
            {
                
                Console.WriteLine("Product Name: {0} Tax: {1}", s[i].name,s[i].calculateTax());           
               
            }
            Console.WriteLine("press any key to continue...");
            Console.ReadKey();

        }
        static void toBeOrdered(List<product> s)
        {
            Console.Clear();
            for (int i = 0; i < s.Count(); i++)
            {
                if (s[i].stockQuantity < s[i].minStockQuantity)
                {
                    Console.WriteLine(s[i].name);
                }
            }
            Console.WriteLine("press any key to continue...");
            Console.ReadKey();
        }
        static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }

        static void readData(string path, List<credentials> users)
        {
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string record;
                while ((record = file.ReadLine()) != null)
                {
                    credentials info = new credentials();
                    info.name = parseData(record, 1);
                    info.password = parseData(record, 2);
                    info.isAdmin = parseData(record, 3);
                    users.Add(info);
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");
            }
        }
        static void signUp(string path, string n,string p, string a)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(n + "," + p + "," + a);
            file.Flush();
            file.Close();
        }

        static string signIn(string n, string p, List<credentials> users)
        {
            string flag = "false";
            for (int x = 0; x < users.Count; x++)
            {
                if (n == users[x].name && p == users[x].password)
                {
                    
                    flag = users[x].isAdmin;
                    break;
                }
            }
            if (flag == "false")
            {
                Console.WriteLine("Invalid User");
                Console.ReadKey();
            }
            return flag;
        }
    }
}
