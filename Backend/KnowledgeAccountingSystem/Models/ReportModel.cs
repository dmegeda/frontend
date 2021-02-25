using System;

namespace KnowledgeAccountingSystem.Models
{
    public class ReportModel
    {
        public int AllTestingUser { get; set; }
        public int PassedUserCount { get; set; }
        public double AvgRate { get; set; }
        public DateTime CreateDate { get; set; }
        public int TestId { get; set; }
    }
}
