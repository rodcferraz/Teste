using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TesteApp.Models.DomainModel.Dbo;

namespace TesteApp.Models.DataModel.Dbo.Mappers
{
    public class CategoriaMap : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMap()
        {
            ToTable("Categoria", "dbo");
            HasKey(c => c.IdCategoria);

            Property(c => c.IdCategoria).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Descricao).HasMaxLength(50).IsRequired();
            //Property(c => c.DataDeletado).IsOptional();

            HasMany(c => c.Produtos).WithRequired(p => p.Categoria).HasForeignKey(p => p.IdCategoria);

        }
    }
}