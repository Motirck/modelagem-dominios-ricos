using Microsoft.EntityFrameworkCore;
using NerdStore.Catalogo.Domain;
using NerdStore.Core.Data;

namespace NerdStore.Catalogo.Data
{
    public class CatalogoContext : DbContext, IUnitOfWork
    {
        public CatalogoContext(DbContextOptions<CatalogoContext> options) : base(options) { }
        
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /// <summary>
            /// O foreach abaixo pega todas as entidades mapeadas, verifica quais as propriedades são
            /// do tipo "string" e mapear automaticamente o tipo da coluna como "varchar(100)" caso
            /// a coluna já não tenha uma especificação diferente. Isso por motivos de segurança, impedindo
            /// a criação de uma coluna como "NVARCHAR(MAX)"
            /// </summary>
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }

            // Vai buscar todas as entidades e seus mappings via "reflection" apenas um vez
            // e irá configrar para que siga as configurações feitas nos mappings
            // como na CategoriaMapping e ProdutoMapping por exemplo
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogoContext).Assembly);
        }

        /// <summary>
        /// No momento de salvar no manco (commit), através do ChangeTracker do Entity Framework, que é o mapeador
        /// de mudanças, o método irá buscar por propriedades que possuam o nome DataCadastro.
        /// </summary>
        /// <returns>bool</returns>
        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                // Se DataCadastro existe e a entidade estiver sendo adicionada, 
                // o DataCadastro irá receber o valor da data do momento do commit
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                // Se a entidade estiver sendo atualizada, qualquer valor em DataCadastro será ignorado
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            // Se o número de linhas afetadas for maior que zero irá retornar true
            return await base.SaveChangesAsync() > 0;
        }
    }
}
