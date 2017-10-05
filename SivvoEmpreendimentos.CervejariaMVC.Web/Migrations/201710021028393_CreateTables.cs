namespace SivvoEmpreendimentos.CervejariaMVC.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Preco = c.Double(nullable: false),
                        Comissao = c.Double(nullable: false),
                        Maioridade = c.Boolean(nullable: false),
                        FabricaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fabricas", t => t.FabricaId)
                .Index(t => t.FabricaId);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MyProperty = c.Int(nullable: false),
                        DistribuidoraId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Distribuidoras", t => t.DistribuidoraId)
                .Index(t => t.DistribuidoraId);
            
            CreateTable(
                "dbo.ItensPedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QtdProdutos = c.Int(nullable: false),
                        PedidoId = c.Int(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pedidoes", t => t.PedidoId)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoId)
                .Index(t => t.PedidoId)
                .Index(t => t.ProdutoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItensPedidoes", "ProdutoId", "dbo.Produtoes");
            DropForeignKey("dbo.ItensPedidoes", "PedidoId", "dbo.Pedidoes");
            DropForeignKey("dbo.Pedidoes", "DistribuidoraId", "dbo.Distribuidoras");
            DropForeignKey("dbo.Distribuidoras", "FabricaId", "dbo.Fabricas");
            DropForeignKey("dbo.Produtoes", "FabricaId", "dbo.Fabricas");
            DropIndex("dbo.ItensPedidoes", new[] { "ProdutoId" });
            DropIndex("dbo.ItensPedidoes", new[] { "PedidoId" });
            DropIndex("dbo.Pedidoes", new[] { "DistribuidoraId" });
            DropIndex("dbo.Produtoes", new[] { "FabricaId" });
            DropIndex("dbo.Distribuidoras", new[] { "FabricaId" });
            DropTable("dbo.ItensPedidoes");
            DropTable("dbo.Pedidoes");
            DropTable("dbo.Produtoes");
            DropTable("dbo.Fabricas");
            DropTable("dbo.Distribuidoras");
        }
    }
}
