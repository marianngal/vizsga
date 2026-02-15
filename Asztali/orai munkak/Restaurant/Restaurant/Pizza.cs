using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Restaurant
{
    internal class Pizza: INotifyPropertyChanged
    {
        private string name;
        private double price;
        private int size;
        private bool vegan;

        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged(nameof(Name)); }
        }

        public double Price
        {
            get => price;
            set { price = value; OnPropertyChanged(nameof(Price)); }
        }       

        public int Size
        {
            get => size;
            set { size = value; OnPropertyChanged(nameof(Size)); }
        }

        public bool Vegan
        {
            get => vegan;
            set { vegan = value; OnPropertyChanged(nameof(Vegan)); }
        }

       
        //public event PropertyChangedEventHandler? PropertyChanged;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public override string ToString()
        {
            return $"{Name} ({Size} cm) {Price} Euro";
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
