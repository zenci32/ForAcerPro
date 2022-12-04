using DataAccess.Repositories.NewsPhotosRepository;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.NewsPhotosRepository
{
    public class NewsPhotosManager : INewsPhotosService
    {
        private readonly INewsPhotosDal _newsPhotosDal;
        public NewsPhotosManager(INewsPhotosDal newsPhotosDal)
        {
            _newsPhotosDal = newsPhotosDal;
        }

        public void Add(NewsPhotos newsPhotos)
        {
           _newsPhotosDal.Add(newsPhotos);
        }

        public void Delete(NewsPhotos newsPhotos)
        {
            _newsPhotosDal.Delete(newsPhotos);
        }

        public Task<List<NewsPhotos>> GetListByNewsId(int NewsId)
        {
            return _newsPhotosDal.GetAll(x => x.NewsId == NewsId);
        }

        public void Update(NewsPhotos newsPhotos)
        {
            _newsPhotosDal.Update(newsPhotos);
        }
    }
}
