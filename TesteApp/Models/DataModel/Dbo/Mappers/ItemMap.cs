using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TesteApp.Models.DomainModel.Dbo;

namespace TesteApp.Models.DataModel.Dbo.Mappers
{
    public class ItemMap : EntityTypeConfiguration<Item>
    {
        public ItemMap()
        {
            ToTable("Item", "dbo");
            HasKey(i => i.IdItem);

            Property(i => i.IdItem).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.IdProduto).IsRequired();
            Property(i => i.IdPedido).IsRequired();
            Property(i => i.Quantidade).IsOptional();
            Property(i => i.Subtotal).IsOptional();

            HasRequired(i => i.Produto).WithMany(p => p.Itens).HasForeignKey(i => i.IdProduto);
            HasRequired(pe => pe.Pedido).WithMany(i => i.Itens).HasForeignKey(pe => pe.IdPedido);
        }
    }
}