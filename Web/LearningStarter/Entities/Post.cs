using System;
using System.Collections.Generic;
using System.Data.OracleClient;

namespace LearningStarter.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
        public List<Social> Socials { get; set; } = new List<Social>();

    }

    public class PostGetDto
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public int CommentId { get; set; }
    }

    public class PostCreateDto
    {
        public DateTimeOffset CreatedAt { get; set; }
        public int CommentId { get; set; }
    }

    public class PostUpdateDto
    {
        public DateTimeOffset CreatedAt { get; set; }
        public int CommentId { get; set; }
    }

    public class PostListingDto
    {
        public DateTimeOffset CreatedAt { get; set; }
        public int CommentId { get; set; }
    }
}
