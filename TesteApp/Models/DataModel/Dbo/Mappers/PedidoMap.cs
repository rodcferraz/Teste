using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TesteApp.Models.DomainModel.Dbo;

namespace TesteApp.Models.DataModel.Dbo.Mappers
{
    public class PedidoMap : EntityTypeConfiguration<Pedido>
    {
          public PedidoMap()
        {
            ToTable("Pedido", "dbo");
            HasKey(i => i.IdPedido);

            Property(i => i.IdPedido).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.DataPedido).IsRequired();
            Property(i => i.Total).IsOptional();

            HasMany(pe => pe.Itens).WithRequired(i => i.Pedido).HasForeignKey(pe => pe.IdPedido);
        }
    }
}