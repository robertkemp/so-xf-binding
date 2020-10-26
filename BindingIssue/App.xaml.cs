using Xamarin.Forms;
using BindingIssue.Services;

namespace BindingIssue
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }
    }
}
