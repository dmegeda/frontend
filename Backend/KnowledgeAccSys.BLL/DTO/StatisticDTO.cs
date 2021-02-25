using KnowledgeAccSys.BLL.Abstracts;
using Microsoft.AspNetCore.Identity;

namespace KnowledgeAccSys.BLL.DTO
{
    public class StatisticDTO : BaseDTO
    {
        public bool IsPassed { get; set; }
        public double UserRating { get; set; }
        public string UserId { get; set; }
        public int TestId { get; set; }
    }
}
