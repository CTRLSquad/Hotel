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
    internal class GuestsWindowViewModel : ViewModelBase
    {
        private ObservableCollection<Guest> _guests;
        public ObservableCollection<Guest> Guests
        {
            get => _guests;
            set => this.RaiseAndSetIfChanged(ref _guests, value);
        }
        private User user { get; set; }
        public GuestsWindowViewModel()
        {
            HotelContext dbContext = new HotelContext();
            dbContext.Guests.Load();
            Guests = dbContext.Guests.Local.ToObservableCollection();
        }
        public void OpenEdit()
        {

        }
    }
}
