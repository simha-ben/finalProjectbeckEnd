using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public partial class Program
    {
        public int Id { get; set; }
        public int? Programer { get; set; }
        public int? Type { get; set; }
        public int? Age { get; set; }
        public int? SumOfParticipants { get; set; }
        public string Description { get; set; }
        public int? Price { get; set; }
        public int? Subject { get; set; }
        public int? Migdar { get; set; }
        public int? Language { get; set; }
        public DateTime? PublishDate { get; set; }
        public string Title { get; set; }
        public int? Status { get; set; }

        public virtual Age AgeNavigation { get; set; }
        public virtual Language LanguageNavigation { get; set; }
        public virtual Migdar MigdarNavigation { get; set; }
        public virtual Users ProgramerNavigation { get; set; }
        public virtual Subject SubjectNavigation { get; set; }
        public virtual SumOfParticipants SumOfParticipantsNavigation { get; set; }
        public virtual Type TypeNavigation { get; set; }
    }
}
