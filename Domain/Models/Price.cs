using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    [Table("Cotacao")]
    public class Price
    {
        [Key]
        public Guid Id { get; set; }
        [Column("NumeroCotacao")]
        public string Number { get; set; }
        public ICollection<ProductQuotation> ProductQuotations { get; set; }
        [Column("Fornecedor")]
        public Provider Provider { get; set; }
        [Column("Comprador")]
        public Purchaser Purchaser { get; set; }
        [Column("Solicitacao")]
        public Proporsal Proporsal { get; set; }
        [Column("PrecoTotal")]
        [DefaultValue(0)]
        public double TotalPrice { get; set; }
        [Column("DataEntrega")]
        public DateTime Deadline { get; set; }
        [Column("PrazoPagamento")]
        public DateTime PaymentTerm { get; set; }

        public Price Clone()
        {
            return this.MemberwiseClone() as Price;
        }

        public void Copy(Price price)
        {
            this.Number = price.Number;
            this.PaymentTerm = price.PaymentTerm;
            this.ProductQuotations = price.ProductQuotations;
            this.Proporsal = price.Proporsal;
            this.Provider = price.Provider;
            this.Purchaser = price.Purchaser;
            this.TotalPrice = price.TotalPrice;
        }
    }
}
