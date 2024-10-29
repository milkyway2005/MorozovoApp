using System;
using System.Windows.Input;

namespace MyRestaurant.ViewModel.BaseVM
{
    public class RelayCommand : ICommand
    {
        //Поля
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        //Конструкторы
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        //События
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //Методы
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
