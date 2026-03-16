using FinalProjectAmit.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FinalProjectAmit.Service;





namespace FinalProjectAmit.ViewModels
{
    public class UsersListViewModel : ViewModelBase
    {
        private ObservableCollection<ObservableUser> _allUsers;
        private ObservableCollection<ObservableUser> _filteredUsers;
        private string _searchText;

        public ObservableCollection<ObservableUser> AllUsers
        {
            get => _allUsers;
            set
            {
                _allUsers = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ObservableUser> FilteredUsers
        {
            get => _filteredUsers;
            set
            {
                _filteredUsers = value;
                OnPropertyChanged();
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                FilterUsers();
            }
        }

        public ICommand GoToEditCommand { get; }
        public ICommand DeleteUserCommand { get; }

        public UsersListViewModel()
        {
            AllUsers = new ObservableCollection<ObservableUser>();
            FilteredUsers = new ObservableCollection<ObservableUser>();

            // ===== עריכה =====
            GoToEditCommand = new Command<ObservableUser>(async (selected) =>
            {
                if (DBMokup.CurrentUser == null || !DBMokup.CurrentUser.IsAdmin)
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Access Denied",
                        "Only admin can edit other users.",
                        "OK");
                    return;
                }

                // שולחים את המשתמש שנבחר בלבד
                await Shell.Current.GoToAsync(
                    "///UserDetailsPage",
                    new Dictionary<string, object>
                    {
                        { "selectedUser", selected.User }
                    });
            });

            // ===== מחיקה =====
            DeleteUserCommand = new Command<ObservableUser>((selected) =>
            {
                if (DBMokup.CurrentUser == null || !DBMokup.CurrentUser.IsAdmin)
                    return;

                DBMokup.RemoveUser(selected.User);

                AllUsers.Remove(selected);
                FilterUsers();
            });
        }

        // טעינת רשימה
        public void OnAppearing()
        {
            AllUsers.Clear();

            foreach (var user in DBMokup.GetAllUsers())
                AllUsers.Add(new ObservableUser(user));

            FilterUsers();
        }

        // סינון
        private void FilterUsers()
        {
            FilteredUsers.Clear();

            var filtered = string.IsNullOrWhiteSpace(SearchText)
                ? AllUsers
                : AllUsers.Where(u =>
                    u.FirstName.Contains(SearchText, System.StringComparison.OrdinalIgnoreCase) ||
                    u.LastName.Contains(SearchText, System.StringComparison.OrdinalIgnoreCase) ||
                    u.UEmail.Contains(SearchText, System.StringComparison.OrdinalIgnoreCase));

            foreach (var user in filtered)
                FilteredUsers.Add(user);
        }
    }
}