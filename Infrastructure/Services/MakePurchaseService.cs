using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Services
{
    public static class MakePurchaseService
    {
        public static Price ProcessProposal(Proporsal proporsal)
        {
            //Calcula cotações
            foreach(Price p in proporsal.Prices)
            {
                foreach(ProductQuotation productQuotation in p.ProductQuotations)
                {
                    p.TotalPrice += productQuotation.Amount * productQuotation.Product.UnitPrice;
                }
            }

            //retorna a cotação de menor valor
            Price price = proporsal.Prices.OrderBy(p => p.TotalPrice).First();
            
            return price;
        }

        public static SupplyOrder CreateSupplyOrder(Price price)
        {
            return new SupplyOrder()
            {
                SelectedPrice = price,
                Authorization = false,
                Number = DateTime.Now.Ticks.ToString(),
                Id = new Guid()
            };
        }

        public static void SendProductsToStock(SupplyOrder supplyOrder)
        {
            //Simula envio (via integração?) para outro módulo ou sistema
            IList<ProductQuotation> ProductQuotations = supplyOrder.SelectedPrice.ProductQuotations.ToList();

            foreach (ProductQuotation p in ProductQuotations)
            {
                //aqui temos acesso ao produto, fonecedor, comprador, preço, quantidade e afins
                //nosso sistema foi retirado de um conjunto de estoque, então não implementamos a integtação final enviando os produtos
                //mas deixamos o código para mostrar que todas as informações necessárias para realizar a entrega
                //estão disponiveis através deste metodo
            }
        }
    }
}
