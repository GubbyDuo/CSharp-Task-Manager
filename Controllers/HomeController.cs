using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcTaskManager.Models;
using System.Text.Json;
using Task = MvcTaskManager.Models.Task;
using Newtonsoft.Json;
using System.Dynamic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;

namespace MvcTaskManager.Controllers;

public class HomeController : Controller
{
    [HttpPost]
    public IActionResult Form(Task task)
    {
        string name = task.Name;
        string description = task.Description;
        Task newTask = new Task(name, description);
        string newJsonString = "";
        using (StreamReader sr = new StreamReader("./data/tasks.json"))
        {
            string json = sr.ReadToEnd();
            List<Task>? taskList = JsonConvert.DeserializeObject<List<Task>>(json);
            taskList.Add(newTask);
            newJsonString = JsonConvert.SerializeObject(taskList);

        }
            
        using (StreamWriter sw = new StreamWriter("./data/tasks.json"))
        {
            sw.WriteLine(newJsonString);
        }
        Response.Redirect("https://localhost:7228/");
        return View();
    }
  
    public IActionResult Index()
    {
        StreamReader sr = new StreamReader("./data/tasks.json");
        string jsonString = sr.ReadToEnd();
        List<Task>? taskList = JsonConvert.DeserializeObject<List<Task>>(jsonString);
        TaskCollection model = new TaskCollection(taskList);
        sr.Close();
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
