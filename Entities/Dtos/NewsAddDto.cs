using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class NewsAddDto
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string NewsTitle { get; set; }
        public string NewsContent { get; set; }
        public IFormFile[]? NewsImages { get; set; } 
    }
}
