using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WomensClinicApp.Models;
using WomensClinicApp.Service.Interfaces;

namespace WomensClinicApp.ViewModels
{
    public class RemindersViewModel : ViewModelBase
    {
        private IDatabase _database;
        private IProfile _profile;

        private ObservableCollection<Appointment> _allAppointments;
        public ObservableCollection<Appointment> AllAppointments
        {
            get { return _allAppointments; }
            set { SetProperty(ref _allAppointments, value); }
        }

        //private Book _Apo;
        //private object _Profile;

        //private IProfile _profile;
        //public Book Apo
        //{
        //    get { return _Apo; }
        //    set { SetProperty(ref _Apo, value); }
        //}

        //public override void Initialize(INavigationParameters parameters)
        //{
        //    base.Initialize(parameters);
        //    Apo = _profile.GetLoggedInUser();
        //}
        public RemindersViewModel(INavigationService navigationService, IDatabase database, IProfile profile) : base(navigationService)
        {
            _database = database;
            _profile = profile;
        }

        public async override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            var user = _profile.GetLoggedInUser();

            var appointments = await _database.GetAppointmentsByUserId(user.ID);

            AllAppointments = new ObservableCollection<Appointment>(appointments);



        }
    }
}
