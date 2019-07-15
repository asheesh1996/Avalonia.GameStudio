using System;
using System.Windows.Input;
using Avalonia.GameStudio.Presentation.ViewModels;
using ReactiveUI;

namespace Avalonia.GameStudio.Shell.ViewModels
{
    /// <summary>
    /// View model for the main menu.
    /// </summary>
    internal sealed class MainMenuViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MainMenuViewModel"/>.
        /// </summary>
        public MainMenuViewModel()
        {
            AboutCommand = ReactiveCommand.Create(AboutCommandImpl);
            ExitCommand = ReactiveCommand.Create(ExitCommandImpl);
        }

        /// <summary>
        /// When executed, displays information about the application.
        /// </summary>
        public ICommand AboutCommand { get; }

        /// <summary>
        /// When executed, closes the application.
        /// </summary>
        public ICommand ExitCommand { get; }

        /// <summary>
        /// Implements the <see cref="AboutCommand"/>.
        /// </summary>
        private void AboutCommandImpl()
        {
            Console.WriteLine("Avalonia GameStudio 0.1!");
            Console.WriteLine("========================");
            Console.WriteLine("Copyright 2020 - Nicolas Musset");
        }

        /// <summary>
        /// Implements the <see cref="ExitCommand"/>.
        /// </summary>
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
