using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IPhotoData
    {
        Task<List<Photo>> GetAll();
        Task Add(Photo photo);
        Task Delete(int id);
        Task Update(int id, Photo photo);
    }
}
