using Hotel.Models;
using Hotel.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    internal class LoginFormViewModel : ViewModelBase
    {
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        private string _message = string.Empty; 
        public LoginForm Owner { get; set; }
        public string Message
        {
            get => _message;
            set => this.RaiseAndSetIfChanged(ref _message, value);
        }
        public LoginFormViewModel(LoginForm loginForm)
        {
            Owner = loginForm;
        }

        public void Auth()
        {
            HotelContext db = new HotelContext();
            User? user = db.Users.Where(u => u.Login == Login && u.Password == Password).FirstOrDefault();
            if (user != null)
            {
                if (user.IsStaff == "1")
                {
                    OpenFormStaff();
                }
                if (user.IsStaff == "0")
                {
                    OpenFormService();
                }
            }
            else
            {
                Message = "Неправильный логин/пароль";
            }
        }
        public void OpenFormStaff()
        {
            var loginForm = new GuestsWindow();
            loginForm.DataContext = new GuestsWindowViewModel();
            loginForm.Show();
            Owner.Close();
        }
        public void OpenFormService()
        {
            var loginForm = new ServicesWindow();
            loginForm.DataContext = new ServicesWindowViewModel();
            loginForm.Show();
            Owner.Close();
        }
    }
}
