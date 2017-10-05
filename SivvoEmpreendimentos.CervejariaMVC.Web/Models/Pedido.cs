using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SivvoEmpreendimentos.CervejariaMVC.Web.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int MyProperty { get; set; }
        public int DistribuidoraId { get; set; }
        public virtual Distribuidora Distribuidora { get; set; }
        public virtual IList<ItensPedido> ItensPedido { get; set; }
    }
}