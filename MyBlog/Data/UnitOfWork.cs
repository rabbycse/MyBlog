using System;

namespace MyBlog.Data
{
    using Repositories;
    using Repositories.Interfaces;
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyBlogDbContext _context = new MyBlogDbContext();
        IBlogRepository _blog;
        ICommentRepository _comment;
        IUserRepository _user;  
       

        public UnitOfWork(MyBlogDbContext context)
        {
            _context = context;
        }

        public UnitOfWork()
        {
        }

        public IBlogRepository Blogs 
        {
            get
            {
                if (_blog == null)
                    _blog = new BlogRepository(_context);

                return _blog; 
            }
        }

        public ICommentRepository Comments 
        {
            get
            {
                if (_comment == null)
                    _comment = new CommentRepository(_context);

                return _comment;
            }
        }
        public IUserRepository Users
        {
            get
            {
                if (_user == null)
                    _user = new UserRepository(_context);

                return _user;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
