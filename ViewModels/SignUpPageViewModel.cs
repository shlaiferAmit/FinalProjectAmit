using FinalProjectAmit.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FinalProjectAmit.Models;
using FinalProjectAmit.Service;
using System.Threading.Tasks;

namespace FinalProjectAmit.ViewModels
{
    public class SignUpPageViewModel : ViewModelBase
    {
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _userEmail = string.Empty;
        private string _userPassword = string.Empty;
        private string _mobile = string.Empty;
        private bool _entryAsPassword = true;

        public ICommand ShowPasswordCommand { get; }
        public ICommand SignUpCommand { get; }
        public ICommand GoToSignInCommand { get; }

        public SignUpPageViewModel()
        {
            ShowPasswordCommand = new Command(TogglePassword);

            SignUpCommand = new Command(async () => await SignUp(), CanSignUp);

            GoToSignInCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("//SignInPage");
            });
        }

        #region Properties

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
                ((Command)SignUpCommand).ChangeCanExecute();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
                ((Command)SignUpCommand).ChangeCanExecute();
            }
        }

        public string UserEmail
        {
            get => _userEmail;
            set
            {
                _userEmail = value;
                OnPropertyChanged();
                ((Command)SignUpCommand).ChangeCanExecute();
            }
        }

        public string UserPassword
        {
            get => _userPassword;
            set
            {
                _userPassword = value;
                OnPropertyChanged();
                ((Command)SignUpCommand).ChangeCanExecute();
            }
        }

        public string Mobile
        {
            get => _mobile;
            set
            {
                _mobile = value;
                OnPropertyChanged();
                ((Command)SignUpCommand).ChangeCanExecute();
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

        // 👁 תמונה מתחלפת
        public string PasswordImage =>
            EntryAsPassword ? "closeeye.png" : "openeye.png";

        #endregion

        #region Methods

        private void TogglePassword()
        {
            EntryAsPassword = !EntryAsPassword;
        }

        private bool CanSignUp()
        {
            return !string.IsNullOrWhiteSpace(FirstName)
                && !string.IsNullOrWhiteSpace(LastName)
                && !string.IsNullOrWhiteSpace(UserEmail)
                && !string.IsNullOrWhiteSpace(UserPassword)
                && !string.IsNullOrWhiteSpace(Mobile);
        }

        private async Task SignUp()
        {
            if (DBMokup.IsEmailExist(UserEmail))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Email already exists",
                    "OK");
                return;
            }

            var newUser = new User
            {
                FirstName = FirstName,
                LastName = LastName,
                UserEmail = UserEmail,
                UserPassword = UserPassword,
                Mobile = Mobile,
                IsAdmin = false
            };

            DBMokup.AddUser(newUser);
            DBMokup.CurrentUser = newUser;

            await Shell.Current.GoToAsync("//MainPage");
        }

        #endregion
    }
}