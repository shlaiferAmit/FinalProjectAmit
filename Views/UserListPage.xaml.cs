using FinalProjectAmit.Service;
using FinalProjectAmit.ViewModels;
namespace FinalProjectAmit.Views;

public partial class UserListPage : ContentPage
{
    public UserListPage()
    {
        InitializeComponent();
        BindingContext = new UsersListViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (DBMokup.CurrentUser == null || !DBMokup.CurrentUser.IsAdmin)
        {
            DisplayAlert("Access Denied",
                "Only admin can access this page.",
                "OK");

            Shell.Current.GoToAsync("..");
            return;
        }

        (BindingContext as UsersListViewModel)?.OnAppearing();
    }
}