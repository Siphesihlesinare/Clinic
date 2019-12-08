using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using WomensClinicApp.Service;
using WomensClinicApp.Service.Interfaces;

namespace WomensClinicApp.ViewModels
{
    public class SignupViewModel : ViewModelBase
    {
        private IDatabase _database;

        private DelegateCommand _submitCommand;
        public DelegateCommand SubmitCommand =>
            _submitCommand ?? (_submitCommand = new DelegateCommand(ExecuteSubmitCommand));

        private Users users;
        public Users UsersDetails;



        public int MyProperty { get; set; }/**/
        private async void ExecuteSubmitCommand()
        {
            var database = new ClinicData ();
            //await connection.(UsersDetails);

            await _database.SaveItemAsync(UsersDetails);

            await NavigationService.NavigateAsync("Login");
        }

        public SignupViewModel(INavigationService navigationService, IDatabase database) : base (navigationService)
        {
           // var users = new Users();
            //UsersDetails = users;
            _database = database;
            UsersDetails = new Users();

        }
    }
}
