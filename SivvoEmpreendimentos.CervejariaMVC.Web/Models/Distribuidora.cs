using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SivvoEmpreendimentos.CervejariaMVC.Web.Models
{
    public class Distribuidora
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int FabricaId { get; set; }
        public virtual Fabrica Fabrica { get; set; }
        public virtual IList<Pedido> Pedidos { get; set; }
    }
}