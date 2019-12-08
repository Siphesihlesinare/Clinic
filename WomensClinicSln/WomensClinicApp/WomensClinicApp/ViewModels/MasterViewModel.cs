using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WomensClinicApp.ViewModels
{
    public class MasterViewModel : ViewModelBase
    {
        private DelegateCommand<string> _navigateCommand;
        public DelegateCommand<string> NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand<string>(ExecuteNavigateCommand));

        void ExecuteNavigateCommand(string view)
        {
            NavigationService.NavigateAsync(view);
        }

        public MasterViewModel(INavigationService navigationService) : base(navigationService)
        {

        }
    }
}
