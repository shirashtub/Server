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
    public class PhotoData : IPhotoData
    {
        private readonly ProjectContext _projectContext;
        public PhotoData(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public async Task<List<Photo>> GetAll()
        {
            List<Photo> photo = await _projectContext.Photos.ToListAsync();
            return photo;
        }

        public async Task Add(Photo photo)
        {
        }

        public async Task Delete(int id)
        {
        }

        public async Task Update(int id, Photo photo)
        {
        }
    }
}
