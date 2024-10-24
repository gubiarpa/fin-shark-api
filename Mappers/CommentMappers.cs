using net8_training.Dtos.Comment;
using net8_training.Models;

namespace net8_training.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToDto(this Comment comment)
        {
            return new CommentDto
            {
                Id = comment.Id,
                Title = comment.Title,
                Content = comment.Content,
                CreatedOn = comment.CreatedOn,
            };
        }
    }
}