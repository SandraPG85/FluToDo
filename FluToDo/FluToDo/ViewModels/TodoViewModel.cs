using FluToDo.Models;

namespace FluToDo.ViewModels
{
    internal class TodoViewModel : ViewModelBase
    {
        private TodoItem todoItem;

        public TodoViewModel(TodoItem item)
        {
            this.todoItem = item;
            this.Id = item.Key;
        }

        public string Id { get; private set; }

        public string Name
        {
            get { return this.todoItem.Name; }
            set
            {
                this.todoItem.Name = value;
                this.RaisePropertyChanged();
            }
        }

        public bool Done
        {
            get { return this.todoItem.IsComplete; }
            set
            {
                this.todoItem.IsComplete = value;
                this.RaisePropertyChanged();
            }
        }
    }
}
