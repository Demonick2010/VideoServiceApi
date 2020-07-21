using VideoService.Services.Interfaces;

namespace TaskManagementApp.Infrastructure.Repositories
{
    public class CategoryOfWork : ICategoryOfWork
    {
        public CategoryOfWork(ICategoryRepository categoryRepository)
        {
            Categories = categoryRepository;
        }

        public ICategoryRepository Categories {get;}
    }
}
