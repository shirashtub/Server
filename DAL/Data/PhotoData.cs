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

        public async Task<bool> Add(string photo)
        {
            await _projectContext.Photos.AddAsync(new Photo() { ImgURL = photo});
            var isOk = _projectContext.SaveChanges() > 0;
            return isOk;
        }

        public async Task<bool> Delete(int id)
        {
            var idPhoto = _projectContext.Photos.FirstOrDefault(x => x.Id == id);
            if (idPhoto == null) { return false; }
            _projectContext.Photos.Remove(idPhoto);
            var isOk = _projectContext.SaveChanges() > 0;
            return isOk;
        }

        public async Task<bool> Update(int id, string photo)
        {
            var idPhoto = _projectContext.Photos.FirstOrDefault(x => x.Id == id);
            if (idPhoto == null) { return false; }
            idPhoto.ImgURL = photo;
            var isOk = _projectContext.SaveChanges() > 0;
            return isOk;
        }
    }
}
