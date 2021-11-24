using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public partial class Users
    {
        public Users()
        {
            MessageFromUserNavigation = new HashSet<Message>();
            MessageToUserNavigation = new HashSet<Message>();
            Program = new HashSet<Program>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Message> MessageFromUserNavigation { get; set; }
        public virtual ICollection<Message> MessageToUserNavigation { get; set; }
        public virtual ICollection<Program> Program { get; set; }
    }
}
