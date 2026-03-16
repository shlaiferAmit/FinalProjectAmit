using FinalProjectAmit.ViewModels;

namespace FinalProjectAmit.Views;

public partial class SignUpPage : ContentPage
{
    public SignUpPage()
    {
        InitializeComponent();
        BindingContext = new SignUpPageViewModel();
    }
}