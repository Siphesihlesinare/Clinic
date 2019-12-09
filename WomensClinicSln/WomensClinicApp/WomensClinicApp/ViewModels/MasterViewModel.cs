using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using WomensClinicApp.Messages;
using WomensClinicApp.Service.Interfaces;

namespace WomensClinicApp.ViewModels
{
    public class MasterViewModel : ViewModelBase

    {
        private IDocumentViewer _documentViewer;
        private IEventAggregator _eventAggregator;

        private string _pdfPath;

        private DelegateCommand _hCommand;
        public DelegateCommand HCommand =>
            _hCommand ?? (_hCommand = new DelegateCommand(ExecuteHCommand));

        private bool _isLoggedIn;
        public bool IsLoggedIn
        {
            get { return _isLoggedIn; }
            set { SetProperty(ref _isLoggedIn, value); }
        }


        void ExecuteHCommand()
        {
            CopyEmbeddedContent("WomensClinicApp.PdfFile.Hygien1.pdf", "Hygien1.pdf");

            _documentViewer.ViewDocument(_pdfPath, "Hygien1.pdf");
        }

        private DelegateCommand<string> _navigateCommand;
        public DelegateCommand<string> NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand<string>(ExecuteNavigateCommand));

        void ExecuteNavigateCommand(string view)
        {
            NavigationService.NavigateAsync(view);
        }

        public MasterViewModel(INavigationService navigation, IDocumentViewer documentViewer, IEventAggregator eventAggregator) : base(navigation)
        {
            _pdfPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            _documentViewer = documentViewer;
            _eventAggregator = eventAggregator;


            _eventAggregator.GetEvent<LoginMessage>().Subscribe(LoginEvent);
        }

        private void LoginEvent()
        {
            IsLoggedIn = true;
        }

        private void CopyEmbeddedContent(string resourceName, string outputFileName)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;

            using (Stream resFilestream = assembly.GetManifestResourceStream(resourceName))
            {
                if (resFilestream == null) return;
                byte[] ba = new byte[resFilestream.Length];
                resFilestream.Read(ba, 0, ba.Length);

                File.WriteAllBytes(Path.Combine(_pdfPath, outputFileName), ba);
            }
        }
    }
}
