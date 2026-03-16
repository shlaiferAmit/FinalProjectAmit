using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProjectAmit.Models; 


namespace FinalProjectAmit.ViewModels
{
    public class ObservableUser : INotifyPropertyChanged
    {
        private User _user;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableUser(User user)
        {
            _user = user;
        }

        // Id
        public int Id
        {
            get => _user.Id;
            set
            {
                if (_user.Id != value)
                {
                    _user.Id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        // First Name
        public string? FirstName
        {
            get => _user.FirstName;
            set
            {
                if (_user.FirstName != value)
                {
                    _user.FirstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        // Last Name
        public string? LastName
        {
            get => _user.LastName;
            set
            {
                if (_user.LastName != value)
                {
                    _user.LastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }

        // Email
        public string? UEmail
        {
            get => _user.UserEmail;
            set
            {
                if (_user.UserEmail != value)
                {
                    _user.UserEmail = value;
                    OnPropertyChanged(nameof(UEmail));
                }
            }
        }

        // Password
        public string? UPassword
        {
            get => _user.UserPassword;
            set
            {
                if (_user.UserPassword != value)
                {
                    _user.UserPassword = value;
                    OnPropertyChanged(nameof(UPassword));
                }
            }
        }

        // תאריך לידה
        public DateTime UBDate
        {
            get => _user.UBDate;
            set
            {
                if (_user.UBDate != value)
                {
                    _user.UBDate = value;
                    OnPropertyChanged(nameof(UBDate));
                }
            }
        }

        // תאריך הרשמה
        public DateTime RegDate
        {
            get => _user.RegDate;
            set
            {
                if (_user.RegDate != value)
                {
                    _user.RegDate = value;
                    OnPropertyChanged(nameof(RegDate));
                }
            }
        }

        // מנהל?
        public bool IsAdmin
        {
            get => _user.IsAdmin;
            set
            {
                if (_user.IsAdmin != value)
                {
                    _user.IsAdmin = value;
                    OnPropertyChanged(nameof(IsAdmin));
                }
            }
        }

        // גישה ל‑User המקורי
        public User User
        {
            get => _user;
            set
            {
                if (_user != value)
                {
                    _user = value;
                    OnPropertyChanged(nameof(User));
                }
            }
        }

        // פונקציה פנימית לעדכון ערכים
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
