
namespace MyBlog.Data
{
    using Repositories.Interfaces;
    public interface IUnitOfWork
    {
        IBlogRepository Blogs { get; } 
        ICommentRepository Comments { get; } 
        IUserRepository Users { get; } 
       
        void Save();
    }
}
