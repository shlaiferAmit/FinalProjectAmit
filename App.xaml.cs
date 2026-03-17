using FinalProjectAmit.ViewModels; 

namespace FinalProjectAmit
{
    public partial class App : Application
    {
        public ObservableUser CurrentUser { get; set; }

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}