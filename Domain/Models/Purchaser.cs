using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    /// <summary>
    /// Classe que representa o comprador
    /// </summary>
    [Table("Comprador")]
    public class Purchaser
    {
        [Key]
        public Guid Id { get; set; }
        [Column("Nome")]
        public string Name { get; set; }

        public Purchaser Clone()
        {
            return this.MemberwiseClone() as Purchaser;
        }

        public void Copy(Purchaser purchaser)
        {
            this.Name = purchaser.Name;
        }
    }
}
