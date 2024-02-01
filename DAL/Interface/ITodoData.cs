using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface ITodoData
    {
        Task<List<Todo>> GetAll();
        Task<bool> Add(Todo todo);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, Todo todo);
        Task<bool> UpdateComplete(int id);
    }
}
