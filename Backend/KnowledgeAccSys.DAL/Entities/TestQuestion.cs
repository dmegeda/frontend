using KnowledgeAccSys.DAL.Abstracts;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeAccSys.DAL.Entities
{
    public class TestQuestion : BaseEntity
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public int AnswerId { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
    }
}
