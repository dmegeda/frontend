using System.ComponentModel.DataAnnotations;

namespace KnowledgeAccSys.DAL.Abstracts
{
    public abstract class BaseEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }
}
