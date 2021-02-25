using KnowledgeAccSys.DAL.Abstracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeAccSys.DAL.Entities
{
    public class Report : BaseEntity
    {
        [Required]
        public int AllTestingUser { get; set; }
        [Required]
        public int PassedUserCount { get; set; }
        [Required]
        public double AvgRate { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }

        public virtual Test Test { get; set; }
    }
}
