using FinalProjectAmit.Models;
using FinalProjectAmit.ViewModels;
using FinalProjectAmit.Service;
namespace FinalProjectAmit.Views;

[QueryProperty(nameof(SelectedUser), "selectedUser")]
public partial class UserDetailsPage : ContentPage
{
    private UserDetailsPageViewModel _viewModel;
    private User? _selectedUser;

    public UserDetailsPage()
    {
        InitializeComponent();

        _viewModel = new UserDetailsPageViewModel();
        BindingContext = _viewModel;
    }

    public User? SelectedUser
    {
        get => _selectedUser;
        set
        {
            _selectedUser = value;
            ApplyUserLogic();
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ApplyUserLogic();
    }

    private void ApplyUserLogic()
    {
        // אם המשתמש מחובר
        if (DBMokup.CurrentUser == null)
            return;

        // 👑 אם זה מנהל ויש משתמש שנשלח לעריכה
        if (DBMokup.CurrentUser.IsAdmin && _selectedUser != null)
        {
            _viewModel.SetUser(_selectedUser);
        }
        else
        {
            // 👤 משתמש רגיל – תמיד עורך את עצמו
            _viewModel.SetUser(DBMokup.CurrentUser);
        }
    }
}