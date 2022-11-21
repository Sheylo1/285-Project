using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Data;

namespace LearningStarter.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string CommentText { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
        public User CreatedByUser { get; set; }
        public int? CreatedByUserId { get; set; }
    }
    public class CommentGetDto
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string CommentText { get; set; }
        public int? CreatedByUserId { get; set; }
        public string CreatedByUserName { get; set; }
    }
    public class CommentCreateDto
    {
        public string CommentText { get; set; }
    }
    public class CommentUpdateDto
    {
        public string CommentText { get; set; }
    }

    public class CommentListingDto
    {
        public DateTimeOffset CreatedAt { get; set; }
        public string CommentText { get; set; }
    }
}
