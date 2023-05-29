using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Hotel.ViewModels;
using Hotel.Views;

namespace Hotel
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                LoginForm loginWindow = new LoginForm();
                loginWindow.DataContext = new LoginFormViewModel();
                desktop.MainWindow = loginWindow;
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}