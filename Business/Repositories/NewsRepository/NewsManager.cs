using Business.Abstract;
using Business.Repositories.NewsPhotosRepository;
using Business.Repositories.NewsRepository.Constants;
using Business.Repositories.NewsRepository.Validation;
using Core.Aspects.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.NewsRepository;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Repositories.NewsRepository
{
    public class NewsManager : INewsService
    {
        private readonly INewsDal _newsDal;
        private readonly IFileService _fileService;
        private readonly INewsPhotosService _newsPhotosService;
        public NewsManager(INewsDal newsDal,IFileService fileService, INewsPhotosService newsPhotosService)
        {
            _newsDal = newsDal;
            _fileService = fileService;
            _newsPhotosService = newsPhotosService;
        }
        [ValidationAspect(typeof(NewsValidator))]
        public async Task<IResult> Add(NewsAddDto newsAddDto)
        {
            if (newsAddDto != null)
            {
                var news = new News()
                {
                    CategoryId = newsAddDto.CategoryId,
                    NewsContent = newsAddDto.NewsContent,
                    NewsTitle = newsAddDto.NewsTitle,
                    UserId = newsAddDto.UserId,
                    NewsAddedAt = DateTime.Now,
                    NewsIsActive = true,
                    NewsIsDeleted = false
                };
                if (newsAddDto.NewsImages!=null)
                {
                     await _newsDal.Add(news);
                    foreach (var item in newsAddDto.NewsImages)
                    {
                        string fileName = _fileService.FileSaveToServer(item, "./Content/news_img/");
                        NewsPhotos newsPhotos = new()
                        {
                            NewsId = news.Id,
                            PhotoPath = fileName
                        };
                        _newsPhotosService.Add(newsPhotos);
                    }
                }
                else
                {
                    return new ErrorResult("Resim alanı Boş",402);
                }
                return new SuccessDataResult<News>(news, NewsMessages.AddedNews, 200);
            }
            return new ErrorResult("Bilgiler Boş Gelemez", 402);
        }
        public async Task<IResult> Delete(int NewsId)
        {
            var result = await _newsDal.Get(p => p.Id == NewsId);
            if (result!=null)
            {
                result.NewsIsDeleted = true;
                await _newsDal.Update(result);
                return new SuccessResult(NewsMessages.DeletedNews, 200);
            }
            return new ErrorResult("Silme İşlemi Başarısız", 404);

        }
        public async Task<IDataResult<List<NewsListDto>>> GetList(int UserId)
        {
            return new SuccessDataResult<List<NewsListDto>>(await _newsDal.GetNewsListByUser(UserId), "Listeleme Başarılı", 200);
        }
        public async Task<IResult> NewsActive(NewsActivePasiveDto newsActivePasiveDto)
        {
            var news = await _newsDal.Get(p => p.Id == newsActivePasiveDto.Id);
            if (news!=null)
            {
                news.NewsIsActive = newsActivePasiveDto.IsActive;
                await _newsDal.Update(news);
                if(newsActivePasiveDto.IsActive==true)
                    return new SuccessResult("Haber Aktif Edilmiştir", 200);
                else
                    return new SuccessResult("Haber Pasif Edilmiştir", 200);

            }
            return new ErrorResult("Boş Veri",404);
        }

       
        public IResult NewsExists(string NewsTitle)
        {
            var result = _newsDal.Get(p => p.NewsTitle==NewsTitle);
            if (result.Result != null)
            {
                return new ErrorResult("Bu Haber DAha Önce Kaydedilmiş", 400);
            }
            return new SuccessResult();
        }
        public async Task<IResult> Update(NewsUpdateDto newsUpdateDto)
        {
            var news = await _newsDal.Get(p => p.Id == newsUpdateDto.Id);
            news.UserId = newsUpdateDto.UserId;
            news.NewsTitle = newsUpdateDto.NewsTitle;
            news.CategoryId = newsUpdateDto.CategoryId;
            news.NewsContent = newsUpdateDto.NewsContent;
            news.NewsIsActive = newsUpdateDto.IsActive;
            await _newsDal.Update(news);
            if (newsUpdateDto.NewsImages!=null)
            {
                var newsImage = await _newsPhotosService.GetListByNewsId(news.Id);
                foreach (var item in newsImage)
                {
                    string path = "./Content/news_img/"+item.PhotoPath;
                    _fileService.FileDeleteToServer(path);
                    _newsPhotosService.Delete(item);
                }

                foreach (var item in newsUpdateDto.NewsImages)
                {
                    string fileName = _fileService.FileSaveToServer(item, "./Content/news_img/");
                    NewsPhotos newsPhotos = new()
                    {
                        NewsId = news.Id,
                        PhotoPath = fileName
                    };
                    _newsPhotosService.Add(newsPhotos);
                }
            }
            return new SuccessResult(NewsMessages.UpdatedNews, 200);
        }
    }
}
