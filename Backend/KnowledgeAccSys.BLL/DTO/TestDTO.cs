using KnowledgeAccSys.BLL.Abstracts;
using System;
using System.Collections.Generic;

namespace KnowledgeAccSys.BLL.DTO
{
    public class TestDTO : BaseDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double MaxRate { get; set; }
        public double MinRatingForPass { get; set; }
        public int Theme_Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }
        public ThemeDTO Theme { get; set; }
        public IEnumerable<TestQuestionDTO> Questions { get; set; }
    }
}
