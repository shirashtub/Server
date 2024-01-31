using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IPostData
    {
        Task<List<Post>> GetAll();
        Task<bool> Add(string content);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, string content);
        Task<bool> UpdateLike(int id);
    }
}
