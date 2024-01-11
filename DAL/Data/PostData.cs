using DAL.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class PostData : IPostData
    {
        private readonly ProjectContext _projectContext;
        public PostData(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public async Task<List<Post>> GetAll()
        {
            List<Post> posts = await _projectContext.Posts.ToListAsync();
            return posts;
        }

        public async Task Add(Post post)
        {
        }
        public async Task Update(int id, Post post)
        {
        }

        public async Task Delete(int id)
        {
        }
    }
}
