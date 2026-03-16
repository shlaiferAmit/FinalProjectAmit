using FinalProjectAmit.ViewModels;

namespace FinalProjectAmit.Views;
public partial class SignInPage : ContentPage
{
    public SignInPage()
    {
        InitializeComponent();
        BindingContext = new SignInPageViewModel();
    }

}
