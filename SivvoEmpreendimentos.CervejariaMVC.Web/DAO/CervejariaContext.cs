using SivvoEmpreendimentos.CervejariaMVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SivvoEmpreendimentos.CervejariaMVC.Web.DAO
{
    public class CervejariaContext : DbContext
    {
        public DbSet<Fabrica> Fabricas { get; set; }
        public DbSet<Distribuidora> Distribuidoras { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItensPedido> ItensPedido { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            builder.Entity<Distribuidora>().HasRequired(d => d.Fabrica);
            builder.Entity<Pedido>().HasRequired(p => p.Distribuidora);
            builder.Entity<ItensPedido>().HasRequired(i => i.Pedido);
            builder.Entity<ItensPedido>().HasRequired(i => i.Produto);
        }
    }
}