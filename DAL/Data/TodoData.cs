using DAL.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class TodoData : ITodoData
    {
        private readonly ProjectContext _projectContext;
        public TodoData(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }
        public async Task<List<Todo>> GetAll()
        {
            List<Todo> todos = await _projectContext.Todos.ToListAsync();
            return todos;
        }
        public async Task<bool> Add(Todo todo)
        {
            //Todo todo = new(description);
            await _projectContext.Todos.AddAsync(todo);
            var isOk = _projectContext.SaveChanges() > 0;
            return isOk;
        }

        public async Task<bool> Delete(int id)
        {
            var idTodo = _projectContext.Todos.FirstOrDefault(x => x.Id == id);
            _projectContext.Todos.Remove(idTodo);
            var isOk = _projectContext.SaveChanges() > 0;
            return isOk;
        }

        public async Task<bool> Update(int id, Todo todo)
        {
            var idTodo = _projectContext.Todos.FirstOrDefault(x => x.Id == id);
            if (idTodo == null)
            {
                return false;
            }
            idTodo.Description = todo.Description;
            idTodo.Date = todo.Date;
            idTodo.IsComplete = todo.IsComplete;
            var isOk = _projectContext.SaveChanges() > 0;
            return isOk;
        }
    }
}
