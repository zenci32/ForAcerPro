using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class NewsPhotos
    {
        public int Id { get; set; }
        public string PhotoPath { get; set; }
        public int NewsId { get; set; }
    }
}
