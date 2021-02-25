using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeAccSys.BLL.Abstracts
{
    public abstract class BaseDTO
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
