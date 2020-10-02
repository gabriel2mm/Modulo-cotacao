using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    [Table("OrdemCompra")]
    public class SupplyOrder : IDocument
    {
        [Key]
        public Guid Id { get; set; }
        [Column("NumeroOrdem")]
        public String Number { get; set; }
        [Column("Autorizacao")]
        public bool Authorization { get; set; }
        [Column("CotacaoSelecionada")]
        public Price SelectedPrice { get; set; }

        public string getDocument()
        {
            return String.Format("Exemplo documento gerado número {0}, Autorizado {1}, cotação selecionada {2}", Number, Authorization, SelectedPrice.Number);
        }

        public SupplyOrder Clone()
        {
            return this.MemberwiseClone() as SupplyOrder;
        }

        public void Copy(SupplyOrder supplyOrder) {
            this.Number = supplyOrder.Number;
            this.SelectedPrice = supplyOrder.SelectedPrice;
            this.Authorization = supplyOrder.Authorization;
        }

    }
}
