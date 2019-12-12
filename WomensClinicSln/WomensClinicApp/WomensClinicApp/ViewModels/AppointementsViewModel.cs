using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using WomensClinicApp.Models;
using WomensClinicApp.Service.Interfaces;

namespace WomensClinicApp.ViewModels
{
    public class AppointementsViewModel : ViewModelBase
    {
        private IDatabase _database;
        private IProfile _profile;
        
        public Users Profile { get; set; }

        private DelegateCommand _make;
        public DelegateCommand Make =>
            _make ?? (_make = new DelegateCommand(ExecuteMake));

        private async void ExecuteMake()
        {
            CurrentAppointment.UserId = LoggedInUser.ID;

            await _database.SaveAppointment(CurrentAppointment);
            await NavigationService.NavigateAsync("Reminders");
        }

        private Appointment _appointment;
        public Appointment CurrentAppointment
        {
            get { return _appointment; }
            set { SetProperty(ref _appointment, value); }
        }

        private Users _loggedInUser;
        private object _Profile;

        public Users LoggedInUser
        {
            get { return _loggedInUser; }
            set { SetProperty(ref _loggedInUser, value); }
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            LoggedInUser = _profile.GetLoggedInUser();
        }

        public AppointementsViewModel(INavigationService navigationService, IDatabase database, IProfile profile) : base(navigationService)
        {
            _profile = profile;
            _database = database;

            CurrentAppointment = new Appointment();



            //Profile = new Users();

        }
    }
}
