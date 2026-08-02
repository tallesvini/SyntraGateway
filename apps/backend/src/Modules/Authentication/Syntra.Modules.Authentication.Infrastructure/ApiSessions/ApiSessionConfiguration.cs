using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Syntra.Modules.Authentication.Domain.ApiSessions;

namespace Syntra.Modules.Authentication.Infrastructure.ApiSessions;

public class ApiSessionConfiguration : IEntityTypeConfiguration<ApiSession>
{
    public void Configure(EntityTypeBuilder<ApiSession> builder)
    {
        builder.ToTable("ApiSessions", "authentication");
        builder.HasKey(y => y.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.TokenStatus).HasConversion<int>().IsRequired();
        builder.Property(x => x.ExpiresAt);
        builder.Property(x => x.LastAccessAt);
        builder.Property(x => x.RevokedAt);
        builder.Property(x => x.RevokedBy);
        builder.Property(x => x.Status).HasConversion<int>().IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.CreatedBy);

        builder.OwnsOne(x => x.ApiClientId, clientId =>
        {
            clientId.Property(y => y.Value).HasColumnName("ApiClientId").IsRequired();
            clientId.HasIndex(y => y.Value);
        });
        
        builder.OwnsOne(x => x.Jti, jti =>
        {
            jti.Property(y => y.Value).HasColumnName("Jti").IsRequired();
            jti.HasIndex(y => y.Value).IsUnique();
        });
        
        builder.OwnsOne(x => x.Origin, origin =>
        {
            origin.Property(y => y.IpAddress).HasColumnName("IpAddress").HasMaxLength(255);
            origin.Property(y => y.UserAgent).HasColumnName("UserAgent").HasMaxLength(128);
            origin.Property(y => y.Device).HasColumnName("Device").HasMaxLength(64);
            origin.Property(y => y.OperationSystem).HasColumnName("OperationSystem").HasMaxLength(64);
            origin.HasIndex(y => y.IpAddress);
        });

        builder.HasIndex(x => new { x.ApiClientId, x.TokenStatus });
        builder.HasIndex(x => x.ExpiresAt);
    }
}