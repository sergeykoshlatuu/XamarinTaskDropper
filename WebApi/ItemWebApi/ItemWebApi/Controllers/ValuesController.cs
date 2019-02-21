using ItemWebApi.Models;
using ItemWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ItemWebApi.Controllers
{
    public class TaskController : ApiController
    {
        ItemTaskService taskService;

        public TaskController()
        {
            taskService = new ItemTaskService();
        }

        [HttpGet]
        // GET api/task/5
        public IEnumerable<TaskItem> GetTaskItem(string id)

        {
            var taskItem = taskService.ItemTasks.GetAllByEmail(id);
            return taskItem;
        }

        [HttpPost]
        // POST api/task
        public void CreateTask([FromBody]TaskItem taskItem)
        {
            taskService.ItemTasks.Create(taskItem);
            taskService.Save();
        }

        [HttpPut]
        // PUT api/task/5
        public void UpdateTask(int id, [FromBody]TaskItem taskItem)
        {
            taskService.ItemTasks.Update(taskItem);
            taskService.Save();
        }

        [HttpDelete]
        // DELETE api/task/5
        public void DeleteTask(int id)
        {
            taskService.ItemTasks.Delete(id);
            taskService.Save();
        }
    
}
}
