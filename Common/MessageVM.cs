using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
  public  class MessageVM
    {
        public string FromUserName { get; set; }
        public string ToUserName { get; set; }
        public int FromUser { get; set; }
        public int ToUser { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
