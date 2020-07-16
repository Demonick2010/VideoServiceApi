using System;
using System.Collections.Generic;
using System.Text;

namespace VideoService.Models.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int VideoId { get; set; }
    }
}
