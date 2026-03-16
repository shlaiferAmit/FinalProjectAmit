using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinalProjectAmit.ViewModels
{
    public class AdminPageViewModel : ViewModelBase
    {
        public ICommand GoToUserListCommand { get; }

        public AdminPageViewModel()
        {
            GoToUserListCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("//UserListPage");
            });
        }
    }
}
