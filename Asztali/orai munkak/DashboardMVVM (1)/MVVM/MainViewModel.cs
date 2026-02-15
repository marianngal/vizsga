using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Data;

namespace MVVM;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<User> users = [];

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsSelected))]
    private User selected;

    public bool IsSelected => Selected is not null;

    /// <summary>
    /// Create a new User and add it to the collection
    /// </summary>
    public void Create(string username)
    {
        Users.Add(new User(username));
    }

    /// <summary>
    /// Add a given user to the collection
    /// </summary>
    public void Add(User user)
    {
        Users.Add(user);
    }

    /// <summary>
    /// Bármilyen gyűjtemény elemeit felveszi
    /// </summary>
    public void AddMany(IEnumerable<User> collection)
    {
        foreach (User user in collection)
        {
            Users.Add(user);
        }
    }

    /// <summary>
    /// Delete selected item
    /// </summary>
    public void Delete()
    {
        if (Selected is not null)
        {
            Users.Remove(Selected);
        }
    }

}
