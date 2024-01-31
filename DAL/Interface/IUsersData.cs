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
        Task<bool> Add(Users users);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, Users users);
    }
}
