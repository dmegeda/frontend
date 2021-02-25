using KnowledgeAccSys.BLL.Abstracts;
using System;

namespace KnowledgeAccSys.BLL.DTO
{
    public class ReportDTO : BaseDTO
    {
        public int AllTestingUser { get; set; }
        public int PassedUserCount { get; set; }
        public double AvgRate { get; set; }
        public DateTime CreateDate { get; set; }
        public int TestId { get; set; }
    }
}
