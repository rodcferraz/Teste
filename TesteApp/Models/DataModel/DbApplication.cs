using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TesteApp.Models.DataModel.Dbo.Mappers;
using TesteApp.Models.DomainModel.Dbo;

namespace TesteApp.Models.DataModel
{
    public class DbApplication : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
      
         public DbApplication()
            : base("name=ProjetoTeste")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new CategoriaMap());
            modelBuilder.Configurations.Add(new ProdutoMap());
            modelBuilder.Configurations.Add(new ItemMap());
            modelBuilder.Configurations.Add(new PedidoMap());           
        }

        public void RegistrarNovo(object entidade)
        {
            Set(entidade.GetType()).Add(entidade);
        }

        public void RegistrarAlterado(object entidade)
        {
            Entry(entidade).State = EntityState.Modified;
        }

        public void RegistrarRemovido(object entidade)
        {
            Entry(entidade).State = EntityState.Deleted;
        }

        public void Salvar()
        {
            SaveChanges();
        }
    }
}