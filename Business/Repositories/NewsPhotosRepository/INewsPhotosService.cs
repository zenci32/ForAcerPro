using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.NewsPhotosRepository
{
    public interface INewsPhotosService
    {
        void Add(NewsPhotos newsPhotos);
        void Update(NewsPhotos newsPhotos);
        void Delete(NewsPhotos newsPhotos);
        Task<List<NewsPhotos>> GetListByNewsId(int NewsId);
    }
}
