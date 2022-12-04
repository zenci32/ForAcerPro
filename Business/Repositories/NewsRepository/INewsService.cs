using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.NewsRepository
{
    public interface INewsService
    {
        Task<IResult> Add(NewsAddDto newsAddDto);
        Task<IResult> Update(NewsUpdateDto newsUpdateDto);
        Task<IResult> NewsActive(NewsActivePasiveDto newsActivePasiveDto);
        Task<IResult> Delete(int NewsId);
        Task<IDataResult<List<NewsListDto>>> GetList( int UserId);
        IResult NewsExists(string NewsTitle);
    }
}
