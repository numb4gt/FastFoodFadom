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

    class MainDrinkVievModel : ViewModelBase
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

        private Drink _foodSelected;
        public bool isSelected = false;
        public List<Drink> go = new List<Drink>();

        public Drink FoodSelected
        {
            get { return _foodSelected; }
            set
            {
                db.SaveChanges();
                _foodSelected = value;
                OnPropertyChanged();
                if (isSelected == false)
                {
                    Updated = (Drink)FoodSelected.Clone();
                }
                isSelected = false;
            }
        }

        private Drink Updated;




        #region ForAdd
        private int _CodOfFood2;
        public int CodOfFood2
        {
            get => _CodOfFood2;
            set => Set(ref _CodOfFood2, value);
        }

        private string _Name2;

        public string Name2
        {
            get => _Name2;
            set => Set(ref _Name2, value);
        }

        private int _Coast2;

        public int Coast2
        {
            get => _Coast2;
            set => Set(ref _Coast2, value);
        }
        #endregion

        public FastFoodFandomContext db = new FastFoodFandomContext();

        private List<Drink> _list;

        public List<Drink> List
        {
            get { return _list; }
            set
            {
                _list = value;
                OnPropertyChanged(nameof(List));
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

        public int LastKey;

        public ICommand AddNewInDB { get; }

        private bool CanAdd(object p) => true;

        private void OnGetAdd(object p)
        {

            if (CodOfFood2 == 0 || Coast2 == 0 || Name2 == null || ImageSource == "C:/Users/USER/Desktop/КП/Проект/FastFoodFadom/FastFoodFadom/Images/no-image.png")
            {
                MessageBox.Show("Все элементы должны быть заполнены и соответствовать типам данных");
                return;
            }

            if (LastKey != CodOfFood2)
            {
                CodOfFood2 = LastKey;
                MessageBox.Show("Нельзя изменять значение кода продукта");
                return;
            }

            Drink dd = new Drink();
            dd.Name = Name2;
            dd.Image = ImageSource;
            dd.DrinkId = CodOfFood2;
            dd.Coast = Coast2;
            db.Drink.Add(dd);

            try
            {
                db.SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Name2 = "";
                Coast2 = 0;
                CodOfFood2 = 0;
                ImageSource = "C:/Users/USER/Desktop/КП/Проект/FastFoodFadom/FastFoodFadom/Images/no-image.png";
                db.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                List = db.Drink.ToList();
                ResetLastIndex();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        public ICommand RefreshData { get; }

        private bool CanRefresh(object p)
        {
            if (FoodSelected != null)
            {
                return true;
            }
            return false;
        }

        private void OnRefreshGet(object p)
        {
            try
            {
                Updated = (Drink)FoodSelected.Clone();
                db.SaveChanges();
                List = db.Drink.ToList();
                db.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
        }

        public ICommand NullNewInDB { get; }

        private bool CanNull(object p)
        {
            if (FoodSelected != null)
            {
                return true;
            }
            return false;
        }

        private void OnGetNull(object p)
        {
            if (FoodSelected.Name != Updated.Name || FoodSelected.Image != Updated.Image || FoodSelected.Coast != Updated.Coast)
            {
                MessageBox.Show("У вас есть несохраненные изменения\nНажмите конпку Сохранить");
                return;
            }
            isSelected = true;
            FoodSelected = null;
        }

        public ICommand DeleteData { get; }

        private bool CanDelete(object p)
        {
            if (FoodSelected != null)
            {
                return true;
            }
            return false;
        }

        private void OnDeleteGet(object p)
        {
            if (FoodSelected.Name != Updated.Name || FoodSelected.Image != Updated.Image || FoodSelected.Coast != Updated.Coast)
            {
                MessageBox.Show("Объект не может быть удален, так как его изменения не зафиксированы\nНажмите конпку Сохранить");
                return;
            }
            db.Drink.Remove(FoodSelected);
            db.SaveChanges();
            db.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            List = db.Drink.ToList();
            ResetLastIndex();
        }

        public void ResetLastIndex()
        {
            LastKey = db.Drink.ToList().Last().DrinkId + 1;
            CodOfFood2 = LastKey;
        }

        public MainDrinkVievModel()
        {

            ResetLastIndex();
            List = db.Drink.ToList();
            AddNewInDB = new LamdaCommand(OnGetAdd, CanAdd);
            ChooseImageCommand = new LamdaCommand(OnChooseImageCommandExecuted, CanChooseImageCommandExecute);
            RefreshData = new LamdaCommand(OnRefreshGet, CanRefresh);
            DeleteData = new LamdaCommand(OnDeleteGet, CanDelete);
            NullNewInDB = new LamdaCommand(OnGetNull, CanNull);
        }

    }

}
