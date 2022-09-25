using System;
using System.Collections.Generic;
using System.Data;

namespace LearningStarter.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
    public class CommentGetDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
    public class CommentCreateDto
    {
        public int UserId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
    public class CommentUpdateDto
    {
        public int UserId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }

    public class CommentListingDto
    {
        public int UserId { get; set; }
        public List<User> Users { get; set; } = new List<User>(); 
        public DateTimeOffset CreatedAt { get; set; }
    }
}
