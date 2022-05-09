using System;
using System.Collections.Generic;
using System.Text;
using FastFoodFadom.ViewModels.Base;

namespace FastFoodFadom.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private string _Title = "FastFoodFandom";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }




    }
}
