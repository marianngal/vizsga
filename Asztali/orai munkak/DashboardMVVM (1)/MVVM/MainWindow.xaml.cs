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
    // Egyszerű lista helyett egy ViewModel példányt tartsunk számon
    MainViewModel viewModel = new();

    public MainWindow()
    {
        InitializeComponent();

        DataContext = viewModel;
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

            viewModel.Create(user);
        }
    }
    
    private void UpdateKattintas(object sender, RoutedEventArgs e)
    {
        if (viewModel.IsSelected)
        {
            // szerkeszti a kijelölt elemet
            EditWindow ablak = new(viewModel.Selected.Name);

            // ablak megnyitása
            bool? válasz = ablak.ShowDialog();
        }
    }

    private void DeleteKattintas(object sender, RoutedEventArgs e)
    {
        viewModel.Delete();
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
            string json = JsonSerializer.Serialize(viewModel.Users);

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

            var lista = JsonSerializer.Deserialize<List<User>>(json);

            viewModel.AddMany(lista);
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