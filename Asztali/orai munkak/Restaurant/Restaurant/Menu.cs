using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace Restaurant
{
    class Menu: INotifyPropertyChanged
    {
        public ObservableCollection<Pizza> Items
        { get; set; }

        private Pizza selected;
        public Pizza Selected
        {
            get => selected;
            set
            {
                if (selected != value)
                {
                    selected = value;
                    OnPropertyChanged(nameof(Selected));
                }
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void Load()
        {
            Items=new ObservableCollection<Pizza>();
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
