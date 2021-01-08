
namespace MyBlog.Data.Repositories
{
    using Entities;
    using Interfaces;
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MyBlogDbContext context) : base(context)
        { }

    }
}
