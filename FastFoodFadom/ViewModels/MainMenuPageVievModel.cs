using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing;
using System.IO.Packaging;
using System.Drawing.Imaging;
using System.Drawing.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using FastFoodFadom.Infrastucture.Commands;
using FastFoodFadom.Models;
using FastFoodFadom.ViewModels.Base;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Win32;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;


namespace FastFoodFadom.ViewModels
{

    class MainMenuPageVievModel : ViewModelBase
    {
        private int _CodOfFood;
        

        public int CodOfFood
        {
            get => _CodOfFood;
            set => Set(ref _CodOfFood, value);
        }

        private string _Name;

        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }

        private int _Coast;

        public int Coast
        {
            get => _Coast;
            set => Set(ref _Coast, value);
        }

        private string _Image;

        public string Image
        {
            get => _Image;
            set => Set(ref _Image, value);
        }

        private Food _foodSelected;
        public bool isSelected = false;
        public List<Food> go = new List<Food>();

        public Food FoodSelected
        {
            get { return _foodSelected; }
            set
            {
                _foodSelected = value;
                OnPropertyChanged();
                Updated = (Food)FoodSelected.Clone();
            }
        }

        private Food Updated;




        #region ForAdd
        private int _CodOfFood2 = 10;
        public int CodOfFood2
        {
            get => _CodOfFood2;
            set => Set(ref _CodOfFood2, value);
        }

        private string _Name2 = "Воппер с салом";

        public string Name2
        {
            get => _Name2;
            set => Set(ref _Name2, value);
        }

        private int _Coast2 = 12;

        public int Coast2
        {
            get => _Coast2;
            set => Set(ref _Coast2, value);
        }
#endregion

        public FastFoodFandomContext db = new FastFoodFandomContext();

        private List<Food> _list;

        public List<Food> List { 
            get { return _list; }
            set { _list = value;
                  OnPropertyChanged(nameof(List));
            } 
        }

        private List<Food> _list2;

        public List<Food> List2
        {
            get { return _list2; }
            set
            {
                _list2 = value;
                OnPropertyChanged(nameof(List2));
            }
        }

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



        public ICommand AddNewInDB { get; }

        private bool CanAdd(object p) => true;

        private void OnGetAdd(object p)
        {
            MessageBox.Show(Updated.Name.ToString());
            MessageBox.Show(Updated.Coast.ToString());
            MessageBox.Show(Updated.FoodId.ToString());
            //Food dd = new Food();
            //dd.Name = Name2;
            //dd.FoodImage = ImageSource;
            //dd.CodOfFood = CodOfFood2;
            //dd.Coast = Coast2;
            //db.Food.Add(dd);

            //try
            //{
            //    db.SaveChanges();
            //    MessageBox.Show("Информация сохранена!");
            //    Name2 = "";
            //    Coast2 = 0;
            //    CodOfFood2 = 0;
            //    ImageSource = "C:/Users/USER/Desktop/КП/Проект/FastFoodFadom/FastFoodFadom/Images/no-image.png";
            //    db.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            //    List = db.Food.ToList();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}
        }


        public ICommand RefreshData { get; }

        private bool CanRefresh(object p) => true;

        private void OnRefreshGet(object p)
        {
            try
            {
                db.SaveChanges();
                List = db.Food.ToList();
                db.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            } catch(Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
        }

        public ICommand NullNewInDB { get; }

        private bool CanNull(object p) => true;

        private void OnGetNull(object p)
        {
            FoodSelected = null;
        }

        public ICommand DeleteData { get; }

        private bool CanDelete(object p) => true;

        private void OnDeleteGet(object p)
        {
            db.Food.Remove(FoodSelected);
            db.SaveChanges();
            db.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            List = db.Food.ToList();
        }

        public MainMenuPageVievModel()
        {
            List = db.Food.ToList();
            AddNewInDB = new LamdaCommand(OnGetAdd, CanAdd);
            ChooseImageCommand = new LamdaCommand(OnChooseImageCommandExecuted, CanChooseImageCommandExecute);
            RefreshData = new LamdaCommand(OnRefreshGet, CanRefresh);
            DeleteData = new LamdaCommand(OnDeleteGet, CanDelete);
            NullNewInDB = new LamdaCommand(OnGetNull, CanNull);
        }

    }

}
