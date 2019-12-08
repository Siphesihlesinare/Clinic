using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WomensClinicApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private DelegateCommand _loginCommand;
        public DelegateCommand LoginCommand =>
            _loginCommand ?? (_loginCommand = new DelegateCommand(ExecuteLoginCommand));

        private DelegateCommand _signupCommand;
        public DelegateCommand SignupCommand =>
            _signupCommand ?? (_signupCommand = new DelegateCommand(ExecuteSignupCommand));

     
       private async void ExecuteSignupCommand()
        {
            await NavigationService.NavigateAsync("Signup");
        }

        private async void ExecuteLoginCommand()
        {
            await NavigationService.NavigateAsync("Login");
        }
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }
    }
}
