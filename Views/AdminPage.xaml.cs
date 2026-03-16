using FinalProjectAmit.Service;

namespace FinalProjectAmit.Views;

public partial class AdminPage : ContentPage
{
    public AdminPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (DBMokup.CurrentUser == null || !DBMokup.CurrentUser.IsAdmin)
        {
            DisplayAlert("Access Denied",
                "You are not allowed to access this page.",
                "OK");

            // ???? ?????
            Shell.Current.GoToAsync("..");
        }
    }

    private async void OnUsersClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//UserListPage");
    }
}