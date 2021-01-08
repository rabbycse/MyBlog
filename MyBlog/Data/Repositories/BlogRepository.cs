using System;
using System.Collections.Generic;

namespace MyBlog.Data.Repositories
{
    using Entities;
    using Interfaces;
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public BlogRepository(MyBlogDbContext context) : base(context)
        { }

    }
}
