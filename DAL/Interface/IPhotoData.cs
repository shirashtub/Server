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
        Task<bool> Add(string photo);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, string photo);
    }
}
