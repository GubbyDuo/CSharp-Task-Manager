namespace MvcTaskManager.Models
{
    public class TaskCollection
    {
        public List<Task>? Tasks { get; set; }

        public TaskCollection(List<Task>? tasks)
        {
            Tasks = tasks;
        }
    }
}
