using Microsoft.EntityFrameworkCore;
using net8_training.Data;
using net8_training.Interfaces;
using net8_training.Models;
using net8_training.Repository.Base;

namespace net8_training.Repository
{
    public class CommentRepository : RepositoryBase, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }
    }
}
