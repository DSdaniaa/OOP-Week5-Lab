using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_Challenge2.BL
{
    class customer
    {
        public List<product> products=new List<product>();

        
        public void addProduct(product item)
        {
            products.Add(item);
        }
        public float calculatePrice()
        {
            float total=0;
            for(int i = 0; i < products.Count(); i++)
            {
                total = total + products[i].price + products[i].calculateTax();
            }
            return total;

        }
    }
}
