using Avalonia.Controls;
using Hotel.Models;
using Hotel.Views;
using Microsoft.CodeAnalysis.Scripting.Hosting;
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
    internal class GuestsWindowViewModel : ViewModelBase
    {
        private Guest _guest;
        public Guest SelectedGuest { get => _guest; set => this.RaiseAndSetIfChanged(ref _guest, value); }

        private ObservableCollection<Guest> _guests;
        public ObservableCollection<Guest> Guests
        {
            get => _guests;
            set => this.RaiseAndSetIfChanged(ref _guests, value);
        }
        private User user { get; set; }
        public GuestsWindowViewModel()
        {
            dbContext = new HotelContext();
            dbContext.Guests.Load();
            Guests = dbContext.Guests.Local.ToObservableCollection();
        }
        public HotelContext dbContext { get; set; }
        public GuestsWindow Owner;
        
        public GuestsWindowViewModel(GuestsWindow Owner) : this()
        {
            this.Owner = Owner;
        }

        public void OpenEdit()
        {
            EditGuestsWindow editGuests = new EditGuestsWindow();
            editGuests.DataContext = new EditWindowGuestsViewModel(SelectedGuest, editGuests);
            editGuests.Show();
            editGuests.Closed += (sender, args) =>
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
            Guests.Remove(SelectedGuest);
        }
        public void CreateGuest()
        {
            Guest newGuest = new Guest();
            EditGuestsWindow editGuests = new EditGuestsWindow();
            Guests.Add(newGuest);
            editGuests.DataContext = new EditWindowGuestsViewModel(newGuest, editGuests);
            editGuests.Show();
            editGuests.Closed += (sender, args) =>
            {
                ReloadWindow();
            };
        }
        public void ReloadWindow()
        {
            var old = Guests;
            Guests = null!;
            Guests = old;
        }
    }
}
