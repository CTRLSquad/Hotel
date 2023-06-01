using Avalonia.X11;
using Hotel.Models;
using Hotel.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    internal class EditWindowGuestsViewModel : ViewModelBase
    {
        private Guest guest;

        public Guest SelectedGuest { get => guest; set => this.RaiseAndSetIfChanged(ref guest, value); }
        EditGuestsWindow Owner;
       
        public EditWindowGuestsViewModel(Guest guest, EditGuestsWindow Owner)
        {
            SelectedGuest = guest;
            this.Owner = Owner;
        }
        
        public void Ok_Button()
        {
            Owner.Close();
        }
    }
}
