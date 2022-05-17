using FastFoodFadom.Infrastucture.Commands;
using FastFoodFadom.Models;
using FastFoodFadom.ViewModels.Base;
using FastFoodFadom.Views.Windows;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

using Microsoft.Win32;

using System.Windows;


namespace FastFoodFadom.ViewModels
{
    class AdminWindowViewModel : ViewModelBase
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

        public MainSnackVievModel Snack { get; set; }

        public MainDrinkVievModel Drink { get; set; }

        public TablePageViewModel Table { get; set; }

        public InteractiveTabloViewModel Tablo { get; set; }

        public CustomerOrderPageViewModel Customer { get; set; }
        public MainMenuPageVievModel Menu { get; set; }

        private object _currentView = new AdminOrdersPageViewModel();
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

        public ICommand ChangeBackCommand { get; }

        private bool CanChangeBackCommandExecute(object p) => true;

        private void OnChangeBackCommandExecuted(object p)
        {
            StartWindow main = new StartWindow();
            main.Show();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = main;


        }

        public ICommand ShowTable { get; }

        private bool CanShowTable(object p) => true;

        private void OnShowTable(object p)
        {
            MessageBox.Show("Нажал");
        }

        public ICommand ShowOrders { get; }

        private bool CanShowOrder(object p) => true;

        private void OnShowOrder(object p)
        {
            MessageBox.Show("Нажал");
        }


        #endregion

        public AdminWindowViewModel()
        {
            Coast = MainCoast.Coast;

            Admin = new AdminOrdersPageViewModel();
            Menu = new MainMenuPageVievModel();
            Drink = new MainDrinkVievModel();
            Snack = new MainSnackVievModel();

            Table = new TablePageViewModel();
            Tablo = new InteractiveTabloViewModel();
          
            Customer = new CustomerOrderPageViewModel();

            ChangeViewCommand = new LamdaCommand(OnChangeViewCommandExecuted, CanChangeViewCommandExecute);
            ChangeBackCommand = new LamdaCommand(OnChangeBackCommandExecuted, CanChangeBackCommandExecute);

            ShowOrders = new LamdaCommand(OnShowOrder,CanShowOrder);
            ShowTable = new LamdaCommand(OnShowTable, CanShowTable);
        }

    }
}

