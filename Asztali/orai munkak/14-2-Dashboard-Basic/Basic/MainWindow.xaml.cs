using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace MVVM;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    // A felhasználók listája
    ObservableCollection<string> users = ["Anita", "Bence", "Csaba", "Anita"];

    public MainWindow()
    {
        InitializeComponent();

        // kössük össze a users nevű listát
        // a grafikus felület ListBoxszával!
        userListBox.ItemsSource = users;
    }

    private void CreateKattintas(object sender, RoutedEventArgs e)
    {
        // Új felhasználó készítésez is felhasználhatnák
        // az előbb elkészített szerkesztő ablakot
        EditWindow ablak = new("");

        bool? válasz = ablak.ShowDialog();

        if (válasz == true)
        {
            string user = ablak.userTextBox.Text;

            if (user.Length > 0)
            {
                users.Add(user);
            }
        }
    }
    
    private void UpdateKattintas(object sender, RoutedEventArgs e)
    {
        // csak akkor akarunk műveletet végezni, ha
        // van kiválsztott elem (nem null), illetve
        // megfelelő típusú is (ebben a példában string)
        if (userListBox.SelectedItem is string user)
        {
            // szerkeszti a kijelölt elemet
            EditWindow ablak = new(user);

            // ablak megnyitása
            bool? válasz = ablak.ShowDialog();

            // ellenőrizni kell, hogy menteni szeretne-e
            if (válasz == true)
            {
                // szerezzük meg a módosított értéket
                string modifiedUser = ablak.userTextBox.Text;

                // tényleg megváltozott vagy ugyanaz maradt?
                if (modifiedUser != user)
                {
                    // az eredetinek mi volt az indexe?
                    int index = userListBox.SelectedIndex;

                    // az ezen a helyen lévő elemet cseréljük le
                    users[index] = modifiedUser;
                }
            }
        }
    }

    private void DeleteKattintas(object sender, RoutedEventArgs e)
    {
        // objektumokat praktikus az elem alapján törölni
        // if (userListBox.SelectedItem is not null)
        // {
        //     users.Remove(userListBox.SelectedItem as string);
        // }

        // primitíveket pedig az indexük alapján
        int index = userListBox.SelectedIndex;
        if (index != -1)
        {
            users.RemoveAt(index);
        }        
    }

    private void SaveKattintas(object sender, RoutedEventArgs e)
    {
        // beépített ablak példányosítása
        SaveFileDialog ablak = new();

        // adjon-e hozzá automatikusan kiterjesztést?
        ablak.AddExtension = true;

        // mi legyen az?
        ablak.DefaultExt = ".json";

        // szűrésnél is jelenjen meg?
        ablak.Filter = "JSON|*.json";

        // ablak megnyitása és válasz mentése (ha volt ilyen?)
        bool? valasz = ablak.ShowDialog();
        
        // csak akkor végzünk művelet, ha ennek az értéke igaz
        if (valasz == true)
        {
            // alakítsunk át a tetszőleges adatunkat JSON formátumra
            string json = JsonSerializer.Serialize(users);

            // szerezzük meg a fájlnevet
            string path = ablak.FileName;

            // végezzük el a fájlba írást
            File.WriteAllText(path, json);
        }
    }

    private void LoadKattintas(object sender, RoutedEventArgs e)
    {
        // Fájlból betölti az adatokat
        OpenFileDialog ablak = new();

        bool? valasz = ablak.ShowDialog();

        if (valasz == true)
        {
            string path = ablak.FileName;

            string json = File.ReadAllText(path);

            users = JsonSerializer.Deserialize<ObservableCollection<string>>(json);

            // ez itt TESCO gazdaságos megoldás
            userListBox.ItemsSource = users;
        }
    }

    private void ExitKattintas(object sender, RoutedEventArgs e)
    {
        // Az aktuális ablak bezárása
        this.Close();

        // az egész alkalmazás beázárása
        // Application.Current.Shutdown();
    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        // mielőtt az ablak bezáródni
        var uzenet = "Biztos bezárod?";
        var fejlec = "Megerősítés";
        var gombok = MessageBoxButton.OKCancel;
        var ikonok = MessageBoxImage.Question;

        // ablak megnyitása és válasz tárolása
        var valasz = MessageBox.Show(uzenet, fejlec, gombok, ikonok);

        // ha a felhasználó a mégsére kattintott
        if (valasz == MessageBoxResult.Cancel)
        {
            // akkor vonjuk vissza az eseményt
            e.Cancel = true;
        }
    }
}