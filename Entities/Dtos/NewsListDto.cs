using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class NewsListDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string NewsTitle { get; set; }
        public string NewsContent { get; set; }
        public DateTime? NewsAddedAt { get; set; }
        public bool NewsIsActive { get; set; }
        public bool NewsIsDeleted { get; set; }
        public List<NewsPhotos> NewsImages { get; set; }
    }
}
