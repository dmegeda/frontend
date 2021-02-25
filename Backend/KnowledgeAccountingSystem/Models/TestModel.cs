using KnowledgeAccountingSystem.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeAccountingSystem.Models
{
    public class TestModel : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double MaxRate { get; set; }
        public double MinRatingForPass { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }
        public string ThemeId { get; set; }
        public IEnumerable<int> Questions_Ids { get; set; }
    }
}
