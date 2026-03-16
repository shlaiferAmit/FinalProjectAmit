using FinalProjectAmit.Service;

namespace FinalProjectAmit.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        DBMokup.CurrentUser = null;

        await Shell.Current.GoToAsync("//SignInPage");
    }

    private async void OnUserListClicked(object sender, EventArgs e)
    {
        if (DBMokup.CurrentUser != null && DBMokup.CurrentUser.IsAdmin)
        {
            await Shell.Current.GoToAsync("//UserListPage");
        }
        else
        {
            await DisplayAlert("Access Denied",
                "Only admin can access the users list.",
                "OK");
        }
    }


    private async void OnAdminClicked(object sender, EventArgs e)
    {
        if (DBMokup.CurrentUser != null && DBMokup.CurrentUser.IsAdmin)
        {
           await Shell.Current.GoToAsync("//AdminPage");
        }
        else
        {
            await DisplayAlert("Access Denied",
               "You are not allowed to access the Admin page.",
               "OK");
        }
    }
}