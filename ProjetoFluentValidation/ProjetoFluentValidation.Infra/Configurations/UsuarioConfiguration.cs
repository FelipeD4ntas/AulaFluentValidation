using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoFluentValidation.Domain.Entidades;

namespace ProjetoFluentValidation.Infra.Configurations;
public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasMaxLength(80);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(80);

        builder.Property(x => x.Idade)
            .IsRequired();
    }
}
