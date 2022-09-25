using System;
using System.Collections.Generic;

namespace LearningStarter.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
        
    }

    public class PostGetDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public int CommentId { get; set; }
    }

    public class PostCreateDto
    {
        public int UserId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public int CommentId { get; set; }
    }

    public class PostUpdateDto
    {
        public int UserId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public int CommentId { get; set; }
    }

    public class PostListingDto
    {
        public int UserId { get; set; }
        public List<User> Users { get; set; } = new List<User>();
        public DateTimeOffset CreatedAt { get; set; }
        public int CommentId { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
