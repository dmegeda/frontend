using KnowledgeAccSys.BLL.Abstracts;
using System.Collections.Generic;

namespace KnowledgeAccSys.BLL.DTO
{
    public class TestQuestionDTO : BaseDTO
    {
        public string Text { get; set; }
        public int AnswerId { get; set; }
        public IEnumerable<AnswerDTO> Answers { get; set; }
    }
}
