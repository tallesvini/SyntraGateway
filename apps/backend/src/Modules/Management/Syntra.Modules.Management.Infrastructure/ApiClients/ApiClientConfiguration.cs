using Microsoft.EntityFrameworkCore;
using Syntra.Modules.Management.Domain.ApiClients;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Syntra.Modules.Management.Infrastructure.ApiClients
{
    public sealed class ApiClientConfiguration : IEntityTypeConfiguration<ApiClient>
    {
        public void Configure(EntityTypeBuilder<ApiClient> builder)
        {
            builder.ToTable("ApiClients", "management");
            builder.HasKey(y => y.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Type).HasConversion<int>().IsRequired();
            builder.Property(x => x.RoleType).HasConversion<int>().IsRequired();
            builder.Property(x => x.IsDeleted).HasDefaultValue(false).IsRequired();
            builder.Property(x => x.DeletedAt);
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.CreatedBy);

            builder.OwnsOne(x => x.Name, name =>
            {
                name.Property(x => x.Value).HasColumnName("Name").HasMaxLength(128).IsRequired();
                name.HasIndex(x => x.Value).IsUnique();
            });

            builder.OwnsOne(x => x.Description, description 
                => description.Property(y => y.Value).HasColumnName("Description").HasMaxLength(255).IsRequired());

            builder.OwnsOne(x => x.Credential, credential =>
            {
                credential.Property(y => y.ClientId).HasColumnName("ClientId").HasMaxLength(255).IsRequired();
                credential.Property(y => y.SecretHash).HasColumnName("SecretHash").HasMaxLength(512).IsRequired();
                credential.Property(y => y.ExpiresAt).HasColumnName("ExpiresAt").IsRequired();

                credential.HasIndex(j => j.ClientId).IsUnique();
            });

            builder.HasIndex(y => y.IsDeleted);

            builder.HasQueryFilter(j => !j.IsDeleted);
        }
    }
}
