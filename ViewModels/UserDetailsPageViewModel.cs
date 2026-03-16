using FinalProjectAmit.Models;
using FinalProjectAmit.Service;
using System.Windows.Input;

namespace FinalProjectAmit.ViewModels
{
    public class UserDetailsPageViewModel : ViewModelBase
    {
        private User _editingUser; // 👈 לא CurrentUser
        private bool _entryAsPassword = true;

        public ICommand UpdateCommand { get; }
        public ICommand ShowPasswordCommand { get; }

        public UserDetailsPageViewModel()
        {
            UpdateCommand = new Command(UpdateUser);
            ShowPasswordCommand = new Command(TogglePassword);
        }

        // 👇 נטען משתמש לעריכה
        public void SetUser(User user)
        {
            _editingUser = user;

            OnPropertyChanged(nameof(FirstName));
            OnPropertyChanged(nameof(LastName));
            OnPropertyChanged(nameof(UserEmail));
            OnPropertyChanged(nameof(Mobile));
            OnPropertyChanged(nameof(UserPassword));
        }

        #region Properties

        public string FirstName
        {
            get => _editingUser?.FirstName;
            set
            {
                if (_editingUser != null)
                {
                    _editingUser.FirstName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string LastName
        {
            get => _editingUser?.LastName;
            set
            {
                if (_editingUser != null)
                {
                    _editingUser.LastName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string UserEmail
        {
            get => _editingUser?.UserEmail;
            set
            {
                if (_editingUser != null)
                {
                    _editingUser.UserEmail = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Mobile
        {
            get => _editingUser?.Mobile ?? string.Empty;
            set
            {
                if (_editingUser != null)
                {
                    _editingUser.Mobile = value;
                    OnPropertyChanged();
                }
            }
        }

        public string UserPassword
        {
            get => _editingUser?.UserPassword;
            set
            {
                if (_editingUser != null)
                {
                    _editingUser.UserPassword = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool EntryAsPassword
        {
            get => _entryAsPassword;
            set
            {
                _entryAsPassword = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PasswordImage));
            }
        }

        public string PasswordImage =>
            EntryAsPassword ? "closeeye.png" : "openeye.png";

        #endregion

        private void TogglePassword()
        {
            EntryAsPassword = !EntryAsPassword;
        }

        private async void UpdateUser()
        {
            if (_editingUser == null)
                return;

            DBMokup.UpdateUser(_editingUser);

            await Application.Current.MainPage.DisplayAlert(
                "Success",
                "User updated successfully",
                "OK");

            await Shell.Current.GoToAsync("..");
        }
    }
}