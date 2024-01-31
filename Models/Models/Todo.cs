using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Todo
    {
        //private static int nowId = 0;
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsComplete { get; set; }

        //static Todo()
        //{
        //    ProjectContext _projectContext;
        //    Todo todos = _projectContext.Todos.ToList().LastOrDefault();
        //    if (todos == null)
        //        nowId = 0;
        //    else
        //        nowId = todos.Id + 1;
        //}

        public Todo(string description)
        {
            //Id = nowId++;
            Description = description;
            Date = DateTime.Now;
            IsComplete = false;
        }
    }
}
