using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SivvoEmpreendimentos.CervejariaMVC.Web.Models
{
    public class ItensPedido
    {
        public int Id { get; set; }
        public int QtdProdutos { get; set; }
        public int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
    }
}