using System;

namespace Produkty.Data.DbModels
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}