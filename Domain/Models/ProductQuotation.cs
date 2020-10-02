using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    [Table("CotacaoProduto")]
    public class ProductQuotation
    {
        [Key]
        public Guid Id { get; set; }
        [Column("produto")]
        public Product Product { get; set; }
        [Column("Cotacao")]
        public Price Price { get; set; }
        [Column("Quantidade")]
        public double Amount { get; set; }

        public ProductQuotation Clone()
        {
            return this.MemberwiseClone() as ProductQuotation;
        }

        public void Copy(ProductQuotation productQuotation)
        {
            this.Price = productQuotation.Price;
            this.Product = productQuotation.Product;
            this.Amount = productQuotation.Amount;
        }
    }
}
