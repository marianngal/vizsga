using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal class Pizza
    {
        public string Name
        { get; set; }
        public double Price
        { get; set; }
        public int Size
        { get; set; }
        public bool Vegan
        { get; set; }

        public override string ToString()
        {
            string s = $"{Name} ({Size} cm) {Price} Euro";
            return s.ToString();
        }

        public Pizza() : this("", 0, 32, false) { }

        public Pizza(string name) : this(name, 0, 32, false) { }

        public Pizza(string name, double price) : this(name, price, 32, false) { }

        public Pizza(string name, double price, int size) : this(name, price, size, false) { }

        public Pizza(string name, double price, int size, bool vegan)
        {
           this.Name = name;
           this.Price = price;
           this.Size = size;
           this.Vegan = vegan;           
        }
    }
}
