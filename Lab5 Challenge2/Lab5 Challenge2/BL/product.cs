using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_Challenge2.BL
{
    class product
    {
        public string name;
        public string category;
        public float price;
        public int stockQuantity;
        public int minStockQuantity;

        public product(string name, string category, float price, int quantity, int minQuantity)
        {
            this.name = name;
            this.category = category;
            this.price = price;
            this.minStockQuantity = minQuantity;
            this.stockQuantity = quantity;
        }
        
        public float calculateTax()
        {
            float tax;
            if (category == "fruit" || category == "Fruit")
            {
                tax = (5 / 100) * price;

            }
            else if (category == "grocery" || category == "Grocery")
            {
                tax = (10 / 100) * price;
            }
            else
            {
                tax = (15 / 100) * price;
            }
            return tax;

        }
    }
}
