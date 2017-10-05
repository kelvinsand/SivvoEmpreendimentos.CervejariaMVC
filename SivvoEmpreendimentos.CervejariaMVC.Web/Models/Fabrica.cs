using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SivvoEmpreendimentos.CervejariaMVC.Web.Models
{
    public class Fabrica
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Endereco { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public virtual IList<Produto> Produtos { get; set; }
        public virtual IList<Distribuidora> Distribuidoras { get; set; }
    }
}