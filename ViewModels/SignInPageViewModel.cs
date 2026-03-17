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
            // 1. ניסיון שליפת המשתמש
            var user = DBMokup.GetUser(UserName, UserPassword);

            if (user != null)
            {
                // 2. עדכון ה-DB המדומה (כפי שעשית)
                DBMokup.CurrentUser = user;

                // 3. עדכון ה-App.CurrentUser (קריטי בשביל ה-Shell)
                // אנחנו הופכים את ה-User ל-ObservableUser כדי שה-UI יגיב לשינויים
                if (Application.Current is App app)
                {
                    app.CurrentUser = new ObservableUser(user);
                }

                // 4. רענון ה-Shell כדי להציג את טאב ה-Admin אם המשתמש הוא מנהל
                if (Shell.Current?.BindingContext is AppShellViewModel vm)
                {
                    vm.Refresh();
                }

                // 5. מעבר לדף הראשי
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