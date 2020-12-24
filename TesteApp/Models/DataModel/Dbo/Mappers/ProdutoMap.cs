using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TesteApp.Models.DomainModel.Dbo;

namespace TesteApp.Models.DataModel.Dbo.Mappers
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            ToTable("Produto", "dbo");
            HasKey(p => p.IdProduto);

            Property(p => p.IdProduto).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.IdCategoria).IsRequired();
            Property(p => p.Nome).HasMaxLength(50).IsRequired();
            Property(p => p.Preco).IsRequired();
            //Property(c => c.DataDeletado).IsOptional();

            HasRequired(p => p.Categoria).WithMany(c => c.Produtos).HasForeignKey(p => p.IdCategoria);
            HasMany(p => p.Itens).WithRequired(i => i.Produto).HasForeignKey(i => i.IdProduto);

        }
    }
}
