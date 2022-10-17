using System;
using FundamentosPooProjPratico.SharedCcontext;

namespace FundamentosPooProjPratico.SubscriptionContext
{
    public class Plan : Base
    {
        public Plan(string title, decimal price)
        {
            Title = title;
            Price = price;
        }

        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}

