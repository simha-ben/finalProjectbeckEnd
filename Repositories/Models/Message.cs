using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public partial class Message
    {
        public int Id { get; set; }
        public int? FromUser { get; set; }
        public int? ToUser { get; set; }
        public DateTime? Date { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }

        public virtual Users FromUserNavigation { get; set; }
        public virtual Users ToUserNavigation { get; set; }
    }
}
