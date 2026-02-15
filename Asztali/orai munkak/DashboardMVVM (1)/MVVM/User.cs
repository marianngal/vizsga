using CommunityToolkit.Mvvm.ComponentModel;

namespace MVVM;

// Model osztály
public partial class User : ObservableObject
{
    [ObservableProperty]
    private string name;

    public User(string username)
    {
        Name = username;
    }
}
