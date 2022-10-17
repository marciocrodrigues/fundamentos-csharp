using System;
using System.Collections.Generic;

namespace FundamentosPooProjPratico.ContentContext
{
    public class Career : Content
    {
        public Career(string title, string url)
            : base(title, url)
        {
            Items = new List<CareerItem>();
        }

        public IList<CareerItem> Items { get; set; }
        public int TotalCourses
        {
            get
            {
                return Items.Count;
            }
        }
    }
}

