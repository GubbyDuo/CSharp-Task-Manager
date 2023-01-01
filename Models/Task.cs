using System.ComponentModel.DataAnnotations;

namespace MvcTaskManager.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Task()
        {
            Name = "Default Name";
            Description = "Default Description";
        }


        public Task(string name, string description)
        { 
            Name = name;
            Description = description;
        }
    }
}
