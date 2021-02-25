using KnowledgeAccSys.DAL.Abstracts;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeAccSys.DAL.Entities
{
    public class Statistic : BaseEntity
    {
        [Required]
        public bool IsPassed { get; set; }
        [Required]
        public double UserRating { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int TestId { get; set; }

        public virtual IdentityUser User { get; set; }
        public virtual Test Test { get; set; }
    }
}
