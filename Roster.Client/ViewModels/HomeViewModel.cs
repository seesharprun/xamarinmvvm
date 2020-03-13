using Roster.Client.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace Roster.Client.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;

        public event PropertyChangedEventHandler PropertyChanged;
        
        public string Title { get; set; } = "ROSTER";

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(FirstName)));
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(LastName)));
            }
        }

        public ObservableCollection<Attendee> Attendees { get; set; }

        public Command AddPersonCommand { get; }

        public HomeViewModel()
        {
            Attendees = new ObservableCollection<Attendee>();
            Attendees.Add(new Attendee { Name = "Delores Feil", Company = "Legros Group" });
            Attendees.Add(new Attendee { Name = "Ann Zboncak", Company = "Ledner - Ferry" });
            Attendees.Add(new Attendee { Name = "Jaime Lesch", Company = "Herzog and Sons" });
            AddPersonCommand = new Command(() => AddPersonExecute());
        }

        private void AddPersonExecute()
        {
            if (String.IsNullOrWhiteSpace(FirstName) || String.IsNullOrWhiteSpace(LastName))
            {
                return;
            }
            Attendee newPerson = new Attendee
            {
                Name = $"{FirstName} {LastName}",
                Company = "N/A"
            };
            Attendees.Add(newPerson);
            FirstName = String.Empty;
            LastName = String.Empty;
        }
    }
}