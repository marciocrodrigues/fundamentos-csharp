using System;
using FundamentosPooProjPratico.NotificationContext;

namespace FundamentosPooProjPratico.SharedCcontext
{
    public abstract class Base : Notifiable
    {
        public Base()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}

