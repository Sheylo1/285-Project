using LearningStarter.Controllers;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace LearningStarter.Entities
{
    public class Social
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int Notifications { get; set; }
        public int Reminders { get; set; }
        public List<User> Users { get; set; } = new List<User>();

    }
    public class SocialGetDto
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int Notifications { get; set; }
        public int Reminders { get; set; }
    }

    public class SocialCreateDto
    {
        public int PostId { get; set; }
        public int Notifications { get; set; }
        public int Reminders { get; set; }
    }

    public class SocialUpdateDto
    {
        public int PostId { get; set; }
        public int Notifications { get; set; }
        public int Reminders { get; set; }
    }

    public class SocialListingDto
    {
        public int PostId { get; set; }
        public int Notifications { get; set; }
        public int Reminders { get; set; }
    }
}
