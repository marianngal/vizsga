using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Company.Models;
using Company.Services;
using System.Collections.ObjectModel;

namespace Company.ViewModel;

partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Employee> employeeCollection;

    [ObservableProperty]
    private Employee selectedEmployee;

    IEmployeeService service;

    public MainViewModel()
    {
        service = new EmployeeService();

        // elkérjük az adatokat
        var data = service.GetAll();

        // ezekkel töltjuk fel a megfigyelhető gyűjteményt
        employeeCollection = new ObservableCollection<Employee>(data);
    }

    [RelayCommand]
    void DeleteSelected()
    {
        // csak akkor töröljünk, ha van kiválasztott dolgozó
        if (selectedEmployee is not null)
        {
            service.Delete(selectedEmployee.Id);
        }
    }
}
