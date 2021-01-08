
namespace MyBlog.Data.Repositories
{
    using Entities;
    using Interfaces;
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(MyBlogDbContext context) : base(context)
        { }

    }
}
