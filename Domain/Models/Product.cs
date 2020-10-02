using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    [Table("Produto")]
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Column("CodProduto")]
        public String ProductCode { get; set; }
        [Column("Nome")]
        [Required]
        public String Name { get; set; }
        [Column("Unidade")]
        [Required]
        public String Unit { get; set; }
        [Column("Medida")]
        [Required]
        public String Measure { get; set; }
        [Column("Fornecedor")]
        [Required]
        public ICollection<ProductProvider> Providers { get; set; }

        [Column("Preço")]
        public double UnitPrice { get; set; }

        public Product Clone()
        {
            return this.MemberwiseClone() as Product;
        }

        public void Copy(Product product)
        {
            this.ProductCode = product.ProductCode;
            this.Measure = product.Measure;
            this.Name = product.Name;
            this.UnitPrice = product.UnitPrice;
            this.Providers = product.Providers;
            this.Unit = product.Unit;
        }
    }
}
