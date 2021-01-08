using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Data;

namespace MyBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        public ActionResult Report() 
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetBlogPostComments()
        {
            var blogs = _unitOfWork.Blogs.GetAll().ToList();
            var comments = _unitOfWork.Comments.GetAll().ToList();
            var users = _unitOfWork.Users.GetAll().ToList();

            var data = (from cmnt in comments
                        join blog in blogs on cmnt.BlogId equals blog.Id
                        join user in users on cmnt.UserId equals user.Id
                        select new
                        {
                            blog.BlogName,
                            Comment = cmnt.Comment1, 
                            user.UserName,
                            Date = Convert.ToDateTime(cmnt.Date).ToShortDateString()
                        })
                        .GroupBy(x => x.BlogName)
                        .Select(n => new
                        {
                            n.FirstOrDefault().BlogName,
                            CommentList = n.Select(c => new
                            {
                                c.Comment,
                                c.UserName,
                                c.Date
                            }),
                            TotalComment = n.Count()
                        }).ToList();

            return Ok(data);
        }
    }
}
