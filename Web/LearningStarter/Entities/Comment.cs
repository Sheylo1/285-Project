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
    }
    public class CommentGetDto
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string CommentText { get; set; }
    }
    public class CommentCreateDto
    {
        public DateTimeOffset CreatedAt { get; set; }
        public string CommentText { get; set; }
    }
    public class CommentUpdateDto
    {
        public DateTimeOffset CreatedAt { get; set; }
        public string CommentText { get; set; }
    }

    public class CommentListingDto
    {
        public DateTimeOffset CreatedAt { get; set; }
        public string CommentText { get; set; }
    }
}
