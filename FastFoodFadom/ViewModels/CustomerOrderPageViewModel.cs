using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using FastFoodFadom.Infrastucture.Commands;
using FastFoodFadom.ViewModels.Base;
using Microsoft.Win32;

namespace FastFoodFadom.ViewModels
{
    class CustomerOrderPageViewModel : ViewModelBase
    {
        private string _ImageSource = "C:/Users/USER/Desktop/КП/Проект/FastFoodFadom/FastFoodFadom/Images/no-image.png";

        /// <summary>Заголовок окна</summary>
        public string ImageSource
        {
            get => _ImageSource;
            set => Set(ref _ImageSource, value);
        }

        public ICommand ChooseImageCommand { get; }

        private bool CanChooseImageCommandExecute(object p) => true;

        private void OnChooseImageCommandExecuted(object p)
        {
            OpenFileDialog FileDialog = new OpenFileDialog();
            FileDialog.Filter = "Files | *.jpg; *.jpeg; *.png";

            Nullable<bool> result = FileDialog.ShowDialog();

            if (result == true)
            {
                var converter = new ImageSourceConverter();
                string filename = FileDialog.FileName;
                try
                {
                    var image = p as Image;
                    image.Source = (ImageSource)converter.ConvertFromString(filename);
                    ImageSource = filename;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: { ex.Message} ");
                }

            }
        }

        public CustomerOrderPageViewModel()
        {
            ChooseImageCommand = new LamdaCommand(OnChooseImageCommandExecuted, CanChooseImageCommandExecute);

        }


    }
}
