using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MVVM
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public EditWindow(string user)
        {
            InitializeComponent();

            userTextBox.Text = user;
        }

        private void MentesKattintas(object sender, RoutedEventArgs e)
        {
            // megerősített, hogy menteni szeretnék
            // a párbeszéd ablak válasza true
            // (ettől a ShowDialog ablak be is záródik)
            this.DialogResult = true;
        }

        private void MegsemKattintas(object sender, RoutedEventArgs e)
        {
            // megggondolta magát
            // a párbeszéd ablak válasza hamis
            // (ettől a ShowDialog ablak be is záródik)
            this.DialogResult = false;
        }
    }
}
