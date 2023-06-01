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
    internal class EditWindowServicesViewModel : ViewModelBase
    {
        private Service service;
        public Service SelectedService { get => service; set => this.RaiseAndSetIfChanged(ref service, value); }
        EditServicesWindow Owner;
        public EditWindowServicesViewModel(Service service, EditServicesWindow Owner)
        {
            SelectedService = service;
            this.Owner = Owner;

        }
        public void Ok_Button()
        {
            Owner.Close();
        }
    }
}
