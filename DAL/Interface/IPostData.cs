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
        Task Add(Post post);
        Task Delete(int id);
        Task Update(int id, Post post);
    }
}
