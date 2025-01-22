using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission3Assignment
{
    internal class FoodItem
    {
        public string name;
        public string category;
        public int quantity;
        public string expirationDate;

        public FoodItem(string name, string category, int quantity, string expirationDate)
        {
            this.name = name;
            this.category = category;
            this.quantity = quantity;
            this.expirationDate = expirationDate;
        }

        public override string ToString()
        {
            return $"- {name}:\n    Category: {category}\n    Quantity: {quantity}\n    Expiration Date: {expirationDate}";
        }
    }
}
