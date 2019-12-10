using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WomensClinicApp.ViewModels
{
    public class AppointementsViewModel : ViewModelBase
    {
       
            private DelegateCommand _make;
        public DelegateCommand Make =>
            _make ?? (_make = new DelegateCommand(ExecuteMake));

        private async void ExecuteMake()
        {
            await NavigationService.NavigateAsync("Reminders");
        }
    }
    
}
