using KnowledgeAccSys.DAL.Abstracts;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeAccSys.DAL.Entities
{
    public class Theme : BaseEntity
    {
        [Required]
        public string Title { get; set; }
    }
}
