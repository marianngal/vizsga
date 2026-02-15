using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class Menu
    {
        public ObservableCollection<Pizza> Items
        { get; set; } = new();
        public Pizza Selected { get; set; }
        public void Load()
        {
            Items.Add(new Pizza("SonGoKu", 9.9, 32, false));
            Items.Add(new Pizza("Margherita", 7.9));
            Items.Add(new Pizza("Carbonara", 8.9, 32));
            Items.Add(new Pizza("Messicano", 12.9));
            Items.Add(new Pizza("Messicano", 24.9, 48));
            Items.Add(new Pizza("Tapenade", 10.9, 28, true));
            Items.Add(new Pizza("Tapenade ", 12.9, 32, true));
        }
    }
}
