using Hotel.Models;
using Hotel.Views;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using SkiaSharp;
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
        private Service _service;

        public Service SelectedService { get => _service; set => this.RaiseAndSetIfChanged(ref _service, value); }
        private ObservableCollection<Service> _services;
        public ObservableCollection<Service> Services
        {
            get => _services;
            set => this.RaiseAndSetIfChanged(ref _services, value);
        }
        private User user { get; set; }
        public ServicesWindowViewModel()
        {
            dbContext = new HotelContext();
            dbContext.Services.Load();
            Services = dbContext.Services.Local.ToObservableCollection();
        }
        public ServicesWindow Owner;
        public ServicesWindowViewModel(ServicesWindow Owner) : this()
        {
            this.Owner = Owner;
        }
        public HotelContext dbContext { get; set; }
        public void OpenEdit()
        {
            EditServicesWindow editService = new EditServicesWindow();
            editService.DataContext = new EditWindowServicesViewModel(SelectedService, editService);
            editService.Show();
            editService.Closed += (sender, args) =>
            {
                ReloadWindow();
            };
        }
        public void SaveButton()
        {
            dbContext.SaveChanges();
        }

        public void DeleteGuest()
        {
            Services.Remove(SelectedService);
        }
        public void CreateGuest()
        {
            Service newService = new Service();
            EditServicesWindow editService = new EditServicesWindow();
            Services.Add(newService);
            editService.DataContext = new EditWindowServicesViewModel(newService, editService);
            editService.Show();
            editService.Closed += (sender, args) =>
            {
                ReloadWindow();
            };
        }
        public void ReloadWindow()
        {
            var old = Services;
            Services = null!;
            Services = old;
        }
    }
}

