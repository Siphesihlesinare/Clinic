using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using WomensClinicApp.Service.Interfaces;

namespace WomensClinicApp.ViewModels
{
    public class AppointementsViewModel : ViewModelBase
    {
        private IDatabase _database;
        public Users Profile { get; set; }

        private DelegateCommand _make;
        public DelegateCommand Make =>
            _make ?? (_make = new DelegateCommand(ExecuteMake));

        private async void ExecuteMake()
        {
            //await _database.SaveItemAsync(Profile);
            await NavigationService.NavigateAsync("Reminders");
        }
      
        public AppointementsViewModel(INavigationService navigationService, IDatabase database) : base(navigationService)

        {
            //_database = database;
            //Profile = new Users();

        }
    }
}
