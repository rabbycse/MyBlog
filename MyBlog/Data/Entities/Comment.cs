using System;
using System.Collections.Generic;

namespace MyBlog.Data.Entities
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int? BlogId { get; set; }
        public string Comment1 { get; set; }
        public DateTime? Date { get; set; }
        public int? UserId { get; set; }
    }
}
