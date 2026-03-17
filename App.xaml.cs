using FinalProjectAmit.ViewModels; // ודאי שהשורה הזו קיימת למעלה

namespace FinalProjectAmit
{
    public partial class App : Application
    {
        // זו השורה שחסרה לך וגורמת לכל השגיאות האדומות:
        public ObservableUser CurrentUser { get; set; }

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}