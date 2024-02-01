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

        public async Task<bool> Add(Post post)
        {
            post.Like = false;
            await _projectContext.Posts.AddAsync(post);
            bool isOk = _projectContext.SaveChanges() > 0;
            return isOk;
        }
        public async Task<bool> Update(int id, Post post)
        {
            var p = await _projectContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
            if (p == null) { return false; }
            p.Content = post.Content;
            bool isOk = _projectContext.SaveChanges() > 0;
            return isOk;
        }

        public async Task<bool> Delete(int id)
        {
            var p = await _projectContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
            if (p == null) { return false; }
            _projectContext.Posts.Remove(p);
            bool isOk = _projectContext.SaveChanges() > 0;
            return isOk;
        }

        public async Task<bool> UpdateLike(int id)
        {
            var p = await _projectContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
            if (p == null) { return false; }
            p.Like = !p.Like;
            bool isOk = _projectContext.SaveChanges() > 0;
            return isOk;
        }
    }
}
