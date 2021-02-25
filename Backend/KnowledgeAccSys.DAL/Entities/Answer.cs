using KnowledgeAccSys.DAL.Abstracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeAccSys.DAL.Entities
{
    public class Answer : BaseEntity
    {
        [Required]
        public string Text { get; set; }

        public virtual ICollection<TestQuestion> Questions { get; set; }
    }
}
