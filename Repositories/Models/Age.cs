using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public partial class Age
    {
        public Age()
        {
            Program = new HashSet<Program>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Program> Program { get; set; }
    }
}
