using FluToDo.Core;
using FluToDo.Models;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace FluToDo.ViewModels
{
    class TodoCreationViewModel : ViewModelBase
    {
        private string name;

        public TodoCreationViewModel(ITodoManager todoManger)
        {
            this.CreateCommand = new Command(async () => { await todoManger.CreateTodoAsync(this.Name); },
                () => !string.IsNullOrEmpty(this.Name));
        }

        public ICommand CreateCommand { get; private set; }

        public string Name
        {
            get { return this.name;  }
            set
            {
                this.name = value;
                this.RaisePropertyChanged();
                ((Command)CreateCommand).ChangeCanExecute();
            }
        }
    }
}
