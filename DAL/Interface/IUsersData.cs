using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IUsersData
    {
        Task<List<Users>> GetAll();
        Task Add(Users users);
        Task Delete(int id);
        Task Update(int id, Users users);
    }
}
