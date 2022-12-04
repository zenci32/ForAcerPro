using Business.Repositories.NewsRepository;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }
        [HttpGet("[action]/{UserId}")]
        public async Task<IActionResult> GetList(int UserId)
        {
            var data=await _newsService.GetList(UserId);
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> NewsAdd([FromForm]NewsAddDto newsAddDto)
        {
            var NewsExists = _newsService.NewsExists(newsAddDto.NewsTitle);
            if (!NewsExists.Success)
            {
                return BadRequest(NewsExists);
            }
            var result=await _newsService.Add(newsAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> NewsUpdate([FromForm]NewsUpdateDto newsUpdateDto)
        {
            var result =await _newsService.Update(newsUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> NewsActivePasive(NewsActivePasiveDto newsActivePasiveDto)
        {
            var result = await _newsService.NewsActive(newsActivePasiveDto);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> NewsDelete(int NewsId)
        {
             var result = await _newsService.Delete(NewsId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
