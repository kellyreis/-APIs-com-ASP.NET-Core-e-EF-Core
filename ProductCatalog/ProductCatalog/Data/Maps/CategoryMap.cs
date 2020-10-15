
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Models;

namespace ProductCatalog.Migrations
{
    public class CategoryMap: IEntityTypeConfiguration<Category>
    {
        
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Define o nome da tabela
            builder.ToTable("Category");
            
            //Adiciona a chave da tabela primaria (ID)
            builder.HasKey(x => x.Id);

            //Define as propriedades da coluna na tabela (titulo)
            builder.Property(x => x.Title).IsRequired().HasMaxLength(120).
                HasColumnType("varchar(120)");
        }
    }
}
