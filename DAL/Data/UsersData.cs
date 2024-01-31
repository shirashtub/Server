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

        public async Task<bool> Add(Users users)
        {
            await _projectContext.Users.AddAsync(users);
            var isOk = _projectContext.SaveChanges() > 0;
            return isOk;
        }

        public async Task<bool> Delete(int id)
        {
            var idUser = _projectContext.Users.FirstOrDefault(x => x.Id == id);
            if (idUser == null) { return false; }
            _projectContext.Users.Remove(idUser);
            var isOk = _projectContext.SaveChanges() > 0;
            return isOk;
        }

        public async Task<bool> Update(int id, Users users)
        {
            var idUser = _projectContext.Users.FirstOrDefault(x => x.Id == id);
            if (idUser == null) { return false; }
            idUser.Name = users.Name;
            idUser.Email = users.Email;
            idUser.Address = users.Address;
            idUser.Phone = users.Phone; 
            var isOk = _projectContext.SaveChanges() > 0;
            return isOk;
        }
    }
}
