using Core.DataAccess.EntityFramework;
using DataAccess.Context.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.NewsRepository
{
    public class EfNewsDal : EfEntityRepositoryBase<News, NewsContextDb>, INewsDal
    {
        public async Task<List<NewsListDto>> GetNewsListByUser(int UserId)
        {
            using (var context = new NewsContextDb())
            {
                var result = from news in context.Newss
                             join user in context.Users on news.UserId equals user.Id
                             join category in context.Categories on news.CategoryId equals category.Id
                             select new NewsListDto
                             {
                                 UserId = news.UserId,
                                 UserName = user.Name,
                                 CategoryId = news.CategoryId,
                                 CategoryName = category.CategoryName,
                                 NewsAddedAt = news.NewsAddedAt,
                                 NewsContent = news.NewsContent,
                                 NewsImages = context.NewsPhotos.Where(x => x.NewsId == news.Id).ToList(),
                                 NewsTitle = news.NewsTitle,
                                 NewsIsActive = news.NewsIsActive,
                                 NewsIsDeleted = news.NewsIsDeleted
                             };
                return await result.Where(x => x.NewsIsDeleted == false && x.NewsIsActive == true && x.UserId == UserId).ToListAsync();
            }
        }
    }
}
