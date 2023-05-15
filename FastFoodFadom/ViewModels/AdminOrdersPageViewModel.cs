using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using FastFoodFadom.Infrastucture.Commands;
using FastFoodFadom.Models;
using FastFoodFadom.ViewModels.Base;

namespace FastFoodFadom.ViewModels
{
    class AdminOrdersPageViewModel : ViewModelBase
    {
        private int SuperAdminKey = 1234;

        private int _SuperKey;

        public int SuperKey
        {
            get => _SuperKey;
            set => Set(ref _SuperKey, value);
        }

        private string _password;

        public string password
        {
            get => _password;
            set => Set(ref _password, value);
        }

        private string _password2;

        public string password2
        {
            get => _password2;
            set => Set(ref _password2, value);
        }

        private string _login;

        public string login
        {
            get => _login;
            set => Set(ref _login, value);
        }





        public ICommand Registration { get; }

        private bool CanRegistration(object p)
        {
                return true;  
        }

        public FastFoodFandomContext db = new FastFoodFandomContext();

        private void OnRegistration(object p)
        {

            if(password == "" || password2 == null || login == null || SuperKey == 0)
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
            if (SuperAdminKey == SuperKey)
            {
                if(password == password2 && password.Length <= 30 && password2.Length <=30)
                {
                    if (login.Length <=30)
                    {
                        try
                        {
                            Admin add = new Admin();
                            add.Password = password;
                            add.Login = login;
                            db.Admin.Add(add);
                            db.SaveChanges();

                            MessageBox.Show("Новый администратор успешно добавлен");

                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Недопустимый формат логина");
                    }
                }
                else
                {
                    MessageBox.Show("Несовпадение паролей или превышенная допустимая длинна");
                }

            }else
            {
                MessageBox.Show("Неверный ключ");
            }

        }

        public ICommand DropDB { get; }

        private bool CanDrop(object p)
        {
            return true;
        }

        private void OnDrop(object p)
        {
            if (SuperAdminKey == SuperKey)
            {
                if (MessageBox.Show($"Вы точно хотите сбросить все имеющиеся заказы?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question)== MessageBoxResult.Yes){
                    try
                    {
                        db.OrderFromMenu.RemoveRange(db.OrderFromMenu);
                        db.SaveChanges();

                        db.Order.RemoveRange(db.Order);
                        db.SaveChanges();
                        MessageBox.Show("База успешно сброшена");
                    }catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Для данного действия необходимо ввести ключ");
            }
         

        }





        public AdminOrdersPageViewModel()
        {
            Registration = new LamdaCommand(OnRegistration, CanRegistration);
            DropDB = new LamdaCommand(OnDrop,CanDrop);
        }



    }
}
