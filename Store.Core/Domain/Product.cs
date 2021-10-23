using Store.Core.Domain.Common;
using System;

namespace Store.Core.Domain
{
    public class Product : ProductBase, IAuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Currency Currency { get; private set; }
        public string CurrencyCode { get; private set; }
        public decimal Price { get; private set; }
        public ProductCategory Category { get; set; }
        public int CategoryId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public Product() { }
        public Product(string name, string description, int categoryId, string currencyCode, decimal price)
        {
            Name = name;
            Description = description;
            CurrencyCode = currencyCode;
            Price = price;
            CategoryId = categoryId;
        }

        public Product(string name, string description, ProductCategory category, Currency currency, decimal price) :this(name, description, category.Id, currency.Code, price)
        {
            Currency = currency;
            Category = category;
        }
    }
}
