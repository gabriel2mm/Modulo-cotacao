using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    /// <summary>
    /// Classe apenas ilustrativa para representar proposta
    /// </summary>
   
    [Table("Solicitacao")]
    public class Proporsal
    {
        [Key]
        public Guid Id { get; set; }
        [Column("NumeroSolicitacao")]
        public string Number { get; set; }
        public ICollection<Price> Prices { get; set; }

        public Proporsal Clone()
        {
            return this.MemberwiseClone() as Proporsal;
        }

        public void Copy(Proporsal proporsal)
        {
            this.Number = proporsal.Number;
            this.Prices = proporsal.Prices;
        }
    }
}
