using System;
using System.Windows.Input;
using Avalonia.GameStudio.Presentation.ViewModels;
using ReactiveUI;

namespace Avalonia.GameStudio.Shell.ViewModels
{
    internal sealed class MainMenuViewModel : ViewModelBase
    {
        public MainMenuViewModel()
        {
            AboutCommand = ReactiveCommand.Create(AboutCommandImpl);
            ExitCommand = ReactiveCommand.Create(ExitCommandImpl);
        }

        public ICommand AboutCommand { get; }
        public ICommand ExitCommand { get; }

        private void AboutCommandImpl()
        {
            Console.WriteLine("Avalonia GameStudio 0.1!");
            Console.WriteLine("========================");
            Console.WriteLine("Copyright 2020 - Nicolas Musset");
        }

        private void ExitCommandImpl()
        {
            var lifetime = Application.Current.ApplicationLifetime;
            if (lifetime is Avalonia.Controls.ApplicationLifetimes.IControlledApplicationLifetime controlled)
            {
                controlled.Shutdown();
                return;
            }

            Environment.Exit(0);
        }
    }
}
