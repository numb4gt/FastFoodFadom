using System;
using System.Collections.Generic;
using System.Text;
using FastFoodFadom.ViewModels.Base;
using FastFoodFadom.Infrastucture.Commands;
using Microsoft.Win32;
using System.Windows.Input;
using FastFoodFadom.Models;
using System.Windows;

namespace FastFoodFadom.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        #region MVVM

        private string _Title = "FastFoodFandom";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        public int _Coast;

        public int Coast
        {
            get => _Coast;
            set => Set(ref _Coast, value);
        }

        public AdminOrdersPageViewModel Admin { get; set; }
        public CustomerOrderPageViewModel Customer { get; set; }
        public MainInfoPageViewModel Info { get; set; }
        public MainMenuPageVievModel Menu { get; set; }

        private object _currentView = new MainInfoPageViewModel();
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Command

        public ICommand ChangeViewCommand { get; }

        private bool CanChangeViewCommandExecute(object p) => true;

        private void OnChangeViewCommandExecuted(object p)
        {
            CurrentView = p;
        }

        #endregion

        public MainWindowViewModel()
        {
            Coast = MainCoast.Coast;
            
            Admin = new AdminOrdersPageViewModel();
            Menu = new MainMenuPageVievModel();
            Info = new MainInfoPageViewModel();
            Customer = new CustomerOrderPageViewModel();

            ChangeViewCommand = new LamdaCommand(OnChangeViewCommandExecuted, CanChangeViewCommandExecute);
            
        }

    }

}
