using KnowledgeAccSys.DAL.Abstracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeAccSys.DAL.Entities
{
    public class Test : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double MaxRate { get; set; }
        [Required]
        public double MinRatingForPass { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime Deadline { get; set; }

        public virtual Theme Theme { get; set; }
        public virtual ICollection<TestQuestion> Questions { get; set; }
    }
}
