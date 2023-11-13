using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM_EntityFramework.Models
{
    internal class Product
    {
        public string ArticleNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string PrimaryCategory { get; set; } = null!;
        public string SubCategory { get; set; } = null!;
    }
}
