using Hotel.Models;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    internal class ServicesWindowViewModel : ViewModelBase
    {
        private ObservableCollection<Service> _services;
        public ObservableCollection<Service> Services
        {
            get => _services;
            set => this.RaiseAndSetIfChanged(ref _services, value);
        }
        private User user { get; set; }
        public ServicesWindowViewModel()
        {
            HotelContext dbContext = new HotelContext();
            dbContext.Services.Load();
            Services = dbContext.Services.Local.ToObservableCollection();
        }
        public void OpenEdit()
        {

        }
    }
}
