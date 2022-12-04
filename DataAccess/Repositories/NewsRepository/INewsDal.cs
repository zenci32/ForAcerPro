using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.NewsRepository
{
    public interface INewsDal: IEntityRepository<News>
    {
        Task<List<NewsListDto>> GetNewsListByUser(int UserId);
    }
}
