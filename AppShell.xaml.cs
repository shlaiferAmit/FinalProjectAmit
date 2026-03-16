using FinalProjectAmit.Service;

namespace FinalProjectAmit;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Navigated += OnNavigated;
    }

    private void OnNavigated(object sender, ShellNavigatedEventArgs e)
    {
        var adminItem = Items
            .OfType<TabBar>()
            .FirstOrDefault()?
            .Items
            .FirstOrDefault(x => x.Route == "AdminPage");

        if (adminItem != null && DBMokup.CurrentUser != null)
        {
            adminItem.IsVisible = DBMokup.CurrentUser.IsAdmin;
        }
    }
}