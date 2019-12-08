using Prism;
using Prism.Ioc;
using WomensClinicApp.Service;
using WomensClinicApp.Service.Interfaces;
using WomensClinicApp.ViewModels;
using WomensClinicApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WomensClinicApp
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) {

        }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            
            await NavigationService.NavigateAsync("Master/NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IDatabase, ClinicData>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();

            containerRegistry.RegisterForNavigation<Login, LoginViewModel>();
            containerRegistry.RegisterForNavigation<Signup, SignupViewModel>();
            containerRegistry.RegisterForNavigation<Content, ContentViewModel>();
            containerRegistry.RegisterForNavigation<Contraceptive, ContraceptiveViewModel>();
            containerRegistry.RegisterForNavigation<Appointements, AppointementsViewModel>();
            containerRegistry.RegisterForNavigation<Hygien, HygienViewModel>();
            containerRegistry.RegisterForNavigation<Reminders, RemindersViewModel>();
            containerRegistry.RegisterForNavigation<Master, MasterViewModel>();
        }
    }
}
