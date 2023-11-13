using FM_EntityFramework.Contexts;
using FM_EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FM_EntityFramework.Services
{
    internal class CategoryService
    {
        private readonly DataContext _context;

        public CategoryService(DataContext context)
        {
            _context = context;
        }

        public async Task CreateCategoryAsync(string categoryName)
        {
            // check if categoryName already exists, if not create category
            if (! await _context.Categories.AnyAsync(x => x.CategoryName == categoryName)) 
            { 
                _context.Categories.Add(new CategoryEntity { CategoryName = categoryName });
                await _context.SaveChangesAsync();
            }
        }

        public async Task<CategoryEntity> GetCategoryAsync(Expression<Func<CategoryEntity, bool>> predicate)
        {
            var categoryEntity = await _context.Categories.FirstOrDefaultAsync(predicate);
            return categoryEntity ?? null!;
        }
    }
}
