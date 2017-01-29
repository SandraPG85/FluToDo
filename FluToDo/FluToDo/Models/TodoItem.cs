namespace FluToDo.Models
{
    /// <summary>
    /// Todo item definition
    /// </summary>
    public class TodoItem
    {
        /// <summary>
        /// The todo description
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Specifies  if the todo is or not completed
        /// </summary>
        public bool IsComplete { get; set; }

        /// <summary>
        /// Todo identifier
        /// </summary>
        public string Key { get; set; }
    }
}
