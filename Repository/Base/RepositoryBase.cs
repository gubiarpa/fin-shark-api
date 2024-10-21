using net8_training.Data;

namespace net8_training.Repository.Base
{
    public class RepositoryBase
    {
        protected readonly ApplicationDbContext _context;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}