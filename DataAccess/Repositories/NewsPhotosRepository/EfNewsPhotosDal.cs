using Core.DataAccess.EntityFramework;
using DataAccess.Context.EntityFramework;
using DataAccess.Repositories.UserOperationClaimRepository;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.NewsPhotosRepository
{
    public class EfNewsPhotosDal: EfEntityRepositoryBase<NewsPhotos, NewsContextDb>, INewsPhotosDal
    {
    }
}
