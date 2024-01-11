using DAL.Interface;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class UsersData : IUsersData
    {
        private readonly ProjectContext _projectContext;
        public UsersData(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public async Task<List<Users>> GetAll()
        {
            List<Users> users = await _projectContext.Users.ToListAsync();
            return users;
        }

        public async Task Add(Users users)
        {
        }

        public async Task Delete(int id)
        {
        }

        public async Task Update(int id, Users users)
        {
        }
    }
}
