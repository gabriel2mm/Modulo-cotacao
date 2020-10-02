using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    [Table("ProdutoFornecedor")]
    public class ProductProvider
    {
        [Column("ProdutoId")]
        public Guid ProductId { get; set; }
        [Column("Produto")]
        public Product Product { get; set; }
        [Column("FornecedorId")]
        public Guid ProviderId { get; set; }
        [Column("Fornecedor")]
        public Provider Provider { get; set; }

        public ProductProvider Clone()
        {
            return this.MemberwiseClone() as ProductProvider;
        }

        public void Copy(ProductProvider productProvider)
        {
            this.Product = productProvider.Product;
            this.Provider = productProvider.Provider;
        }
    }
}
