using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SivvoEmpreendimentos.CervejariaMVC.Web.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public double Comissao { get; set; }
        public bool Maioridade { get; set; }
        public int FabricaId { get; set; }
        public virtual Fabrica Fabrica { get; set; }
    }
}