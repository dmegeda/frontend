using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace KnowledgeAccSys.Tests
{
    public static class ContentCreator
    {
        public static StringContent CreateStringContent(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.Default,
                "application/json");
        }
    }
}
