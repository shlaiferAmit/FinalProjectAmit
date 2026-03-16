using FinalProjectAmit.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinalProjectAmit.ViewModels
{
    public class SignInPageViewModel : ViewModelBase
    {
        private string _userName = string.Empty;
        private string _userPassword = string.Empty;
        private bool _entryAsPassword = true;

        public ICommand SignInCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand GoToSignUpCommand { get; }

        public SignInPageViewModel()
        {
            SignInCommand = new Command(OnSignIn, CanSignIn);

            ShowPasswordCommand = new Command(TogglePassword);

            GoToSignUpCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("//SignUpPage");
            });
        }

        // ===== Properties =====

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
                ((Command)SignInCommand).ChangeCanExecute();
            }
        }

        public string UserPassword
        {
            get => _userPassword;
            set
            {
                _userPassword = value;
                OnPropertyChanged();
                ((Command)SignInCommand).ChangeCanExecute();
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

        // 👁 תמונה דינמית
        public string PasswordImage =>
            EntryAsPassword ? "closeeye.png" : "openeye.png";

        // ===== Commands =====

        private void TogglePassword()
        {
            EntryAsPassword = !EntryAsPassword;
        }

        private bool CanSignIn()
        {
            return !string.IsNullOrWhiteSpace(UserName)
                && !string.IsNullOrWhiteSpace(UserPassword);
        }

        private async void OnSignIn()
        {
            var user = DBMokup.GetUser(UserName, UserPassword);

            if (user != null)
            {
                DBMokup.CurrentUser = user;
                await Shell.Current.GoToAsync("//MainPage");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Email or password incorrect",
                    "OK");
            }
        }
    }
}