using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace FinalProjectAmit.ViewModels
{
    public class AppShellViewModel : INotifyPropertyChanged
    {
        // המאפיין שיקבע אם הטאב יוצג או יוסתר
        public bool IsAdmin => (Application.Current as App)?.CurrentUser?.IsAdmin ?? false;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // פונקציה שתקראי לה לאחר התחברות כדי לרענן את התפריט
        public void Refresh()
        {
            OnPropertyChanged(nameof(IsAdmin));
        }
    }
}
