using System.Collections.Generic;

namespace LearningStarter.Entities
{
    public class Social
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }  
        public int CommentId { get; set; }
        public Comment Comment { get; set; }    
        public int Notifications { get; set; }
        public int Reminders { get; set; }


    }
    public class SocialGetDto
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int CommentId { get; set; }
        public int Notifications { get; set; }
        public int Reminders { get; set; }
    }

    public class SocialCreateDto
    {
        public int PostId { get; set; }
        public int CommentId { get; set; }
        public int Notifications { get; set; }
        public int Reminders { get; set; }
    }

    public class SocialUpdateDto
    {
        public int PostId { get; set; }
        public int CommentId { get; set; }
        public int Notifications { get; set; }
        public int Reminders { get; set; }
    }

    public class SocialListingDto
    {
        public int PostId { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
        public int CommentId { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public int Notifications { get; set; }
        public int Reminders { get; set; }
    }
}
