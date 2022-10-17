using System;
using FundamentosPooProjPratico.SharedCcontext;

namespace FundamentosPooProjPratico.ContentContext
{
    public class Lecture : Base
    {
        public int Order { get; set; }
        public string Title { get; set; }
        public int DurationInMinutes { get; set; }
    }
}

