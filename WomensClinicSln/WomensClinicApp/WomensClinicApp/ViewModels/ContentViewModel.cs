using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using WomensClinicApp.Service.Interfaces;

namespace WomensClinicApp.ViewModels
{
    public class ContentViewModel : ViewModelBase
    {
        private IDocumentViewer _documentViewer;
        private string _pdfPath;


        private DelegateCommand _conCommand;
        public DelegateCommand ConCommand =>
            _conCommand ?? (_conCommand = new DelegateCommand(ExecuteCommandName));

       private async void ExecuteCommandName()
        {
            CopyEmbeddedContent("WomensClinicApp.PdfFile.contra_choices.pdf", "contra_choices.pdf");

            _documentViewer.ViewDocument(_pdfPath, "contra_choices.pdf");

            //   await NavigationService.NavigateAsync("Contraceptive");
        }

        private DelegateCommand _appCommand;
        public DelegateCommand AppCommand =>
            _appCommand ?? (_appCommand = new DelegateCommand(ExecuteAppCommand));

       private async void ExecuteAppCommand()
        {
            await NavigationService.NavigateAsync("Appointements");
        }

        private DelegateCommand _hyCommand;
        public DelegateCommand HyCommand =>
            _hyCommand ?? (_hyCommand = new DelegateCommand(ExecuteHyCommand));

        private async void ExecuteHyCommand()
        {
            CopyEmbeddedContent("WomensClinicApp.PdfFile.Hygien1.pdf", "Hygien1.pdf");

            _documentViewer.ViewDocument(_pdfPath, "Hygien1.pdf");

            // await NavigationService.NavigateAsync("Hygien");
        }

        private DelegateCommand _reCommand;
        public DelegateCommand ReCommand =>
            _reCommand ?? (_reCommand = new DelegateCommand(ExecuteReCommand));

       private async void ExecuteReCommand()
        {
            await NavigationService.NavigateAsync("Reminders");
        }


        public ContentViewModel(INavigationService navigation, IDocumentViewer documentViewer) : base(navigation)
        {
            _pdfPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            _documentViewer = documentViewer;
        }


        //{ private DelegateCommand _conCommand;
        //public DelegateCommand ConCommand =>
        //    _conCommand ?? (_conCommand = new DelegateCommand(ExecuteConCommand));

        //public async void ExecuteConCommand()
        //{
        //    await NavigationService.NavigateAsync("Contraceptive");
        //}
        //public ContraceptiveViewModel(INavigationService navigation) : base(navigation)
        //{

        //}

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
