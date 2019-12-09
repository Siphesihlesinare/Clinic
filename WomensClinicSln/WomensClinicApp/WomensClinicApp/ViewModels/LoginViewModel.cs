using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using WomensClinicApp.Messages;
using WomensClinicApp.Models;
using WomensClinicApp.Service;
using WomensClinicApp.Service.Interfaces;

namespace WomensClinicApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private IEventAggregator _eventAggregator;

        public Login LoginDetails { get; set; }
        private IDatabase _database;
        private DelegateCommand _commandSend;
        public DelegateCommand CommandSend =>
           _commandSend ?? (_commandSend = new DelegateCommand(ExecuteCommandSend));

        private async void ExecuteCommandSend()
        {
            _database = new ClinicData();
            var users = await _database.GetItemsAsync();
            foreach(var item in users)
            {
                var user = _database.GetUserByIDNumber(item.IDN);
                if(users != null)
                {
                    //var

                   
                }
            }

            //TODO when you are done  do this
            _eventAggregator.GetEvent<LoginMessage>().Publish();

            await NavigationService.NavigateAsync("Content");
        }
        public LoginViewModel(INavigationService navigation, IEventAggregator eventAggregator) : base(navigation)
        {
            var login = new Login();
            LoginDetails = login;

            _eventAggregator = eventAggregator;
        }

    }


}
