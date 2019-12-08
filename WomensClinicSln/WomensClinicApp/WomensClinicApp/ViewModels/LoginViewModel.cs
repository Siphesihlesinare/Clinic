using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WomensClinicApp.ViewModels
{
    public class LoginViewModel : ViewModelBase

    {
        private DelegateCommand _commandSend;
        public DelegateCommand CommandSend =>
           _commandSend ?? (_commandSend = new DelegateCommand(ExecuteCommandSend));

        private async void ExecuteCommandSend()
        {
            await NavigationService.NavigateAsync("Content");
        }
        public LoginViewModel(INavigationService navigation) : base(navigation)
        {

        }

    }


}
