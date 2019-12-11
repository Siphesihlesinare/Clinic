using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
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

        //private IEventAggregator _eventAggregator;
        private IProfile _profile;

        public Login LoginDetails { get; set; }
        private IDatabase _database;

        private DelegateCommand _commandSend;
        public DelegateCommand CommandSend =>
           _commandSend ?? (_commandSend = new DelegateCommand(ExecuteCommandSend));

        public bool PasswExist { get; set; }
        public List<Users> UserDetails { get; set; }
        private IPageDialogService _dialogService;
        private IDatabase database;
        private IPageDialogService pageDialogService;
        private object navigationService;
      //  private IProfile profile;

        public Users UserInfo { get; set; }
        public Users Access { get; set; }

        public LoginViewModel(INavigationService navigationService, IDatabase database, IPageDialogService pageDialogService, IProfile userProfile) : base(navigationService)

        {

            _database = database;
            _profile = userProfile;
            _dialogService = pageDialogService;
            var loginInfor = new Users();
            UserInfo = loginInfor;

            //var login = new Login();
            //LoginDetails = login;

            //_eventAggregator = eventAggregator;
        }
        public override void Initialize(INavigationParameters parameters)
        {
            //base.Initialize(parameters);
            UserInfo = new Users();
        }

        private async void ExecuteCommandSend()
        {

            var knownUser = await _database.GetUserByIDNumber(UserInfo.IDN);
            //var Infor = UserInfo;I
            if (UserInfo.IDN == null)
            {
                await _dialogService.DisplayAlertAsync("Alert", "ID Number is required!", "ok");
            }
            else if (UserInfo.Password == null)
            {
                await _dialogService.DisplayAlertAsync("Alert", "PassWord is required", "ok");
            }
            else if (UserInfo.Password != knownUser.Password || UserInfo.IDN != knownUser.IDN)
            {
                await _dialogService.DisplayAlertAsync("Alert", "Wrong ID Number or Password, Please Try again!", "ok");
            }
            else
            {
                if (knownUser.Password == UserInfo.Password)
                {
                    PasswExist = true;
                    _profile.SetLoggedinUser(knownUser);
                    await NavigationService.NavigateAsync("Content");
                    return;
                }
                else
                {
                    PasswExist = false;
                }
                if (PasswExist == false)
                {
                    await _dialogService.DisplayAlertAsync("ALERT!", "Incorrect password, please try again", "ok");
                }

            }


        }

      
    }


    }




